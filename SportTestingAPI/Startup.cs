using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using SportTestingAPI.Repository;
using SportTestingAPI.BasicAuthentication;
using System.Security.Claims;
using Microsoft.IdentityModel.Protocols;
using SportTestingAPI.Models;

namespace SportTestingAPI
{
    public class Startup
    {
        private object configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
       // public Startup(IConfiguration configuration)
       // {
       //     Configuration = configuration;
        //}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );

            services.AddDbContext<ApplicationDbContext>(
        options => options.EnableSensitiveDataLogging()
        );

            services.AddMvc();


            services.AddScoped<IAthlete_metricsRepository, Athlete_metricsRepository>();
            services.AddScoped<ICombine_athlete_metricsRepository, Combine_athlete_metricsRepository>();
            services.AddScoped<ICombine_drillsRepository, Combine_drillsRepository>();
            services.AddScoped<ICombine_metricsRepository, Combine_metricsRepository>();
            services.AddScoped<ICombinesRepository, CombinesRepository>();
            services.AddScoped<IDrill_dataRepository, Drill_dataRepository>();
            services.AddScoped<IDrillsRepository, DrillsRepository>();
            services.AddScoped<IParticipantsRepository, ParticipantsRepository>();
            services.AddScoped<ISportsRepository, SportsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            services.AddLogging(configure => configure.AddConsole()).AddTransient<ParticipantsRepository>();
            services.Configure<AppSettings>(Configuration.GetSection("ConnectionStrings"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseMvc();
        //}

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ApplicationDbContext personContext)
        {
   

            string User = Configuration.GetValue<string>("BasicAuthentication:User");
            string Password = Configuration.GetValue<string>("BasicAuthentication:Password");

           
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            app.Map("/middelware", b =>
            {
                b.UseMiddleware<BasicAuthMiddleware>("sporttesting.com",User,Password);
                b.UseMvc();
            });

           

            app.UseMvc();

        
        }
    }
}
