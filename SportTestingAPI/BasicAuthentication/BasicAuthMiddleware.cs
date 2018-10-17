
namespace SportTestingAPI.BasicAuthentication
{
    using System;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string realm;
        public string UserName { get; set; }
        public string Password { get; set; }
        public BasicAuthMiddleware(RequestDelegate next, string realm,string UserName, string UserPassword)
        {
            this.next = next;
            this.realm = realm;
            this.UserName = UserName;
            this.Password = UserPassword;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                // Get the encoded username and password
                var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();

                // Decode from Base64 to string
                var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                // Split username and password
                var username = decodedUsernamePassword.Split(':', 2)[0];
                var password = decodedUsernamePassword.Split(':', 2)[1];

                // Check if login is correct
                if (IsAuthorized(username, password))
                {
                    await next.Invoke(context);
                    return;
                }
            }

            // Return authentication type (causes browser to show login dialog)
            context.Response.Headers["WWW-Authenticate"] = "Basic";

            // Add realm if it is not null
            if (!string.IsNullOrWhiteSpace(realm))
            {
                context.Response.Headers["WWW-Authenticate"] += $" realm=\"{realm}\"";
            }

            // Return unauthorized
            context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
        }

        // Make your own implementation of this
        public bool IsAuthorized(string username, string password)
        {


            // Check that username and password are correct
            return username.Equals(this.UserName, StringComparison.InvariantCultureIgnoreCase)
                   && password.Equals(this.Password );
        }
    }
}