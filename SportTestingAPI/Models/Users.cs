using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;

namespace SportTestingAPI.Models
{
    public  class Users
    {
        public long? id { get; set; }

        //[ForeignKey("Users")]
        public long? user_id { get; set; }
        public long? parent_user_id { get; set; }
        public long? organization_id { get; set; }
        public Int32? master_id { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }

        public string email { get; set; }
        public string password { get; set; }

        public string activation_code { get; set; }

        public string share_key { get; set; }
        public long? role_id { get; set; }
        public long? status_id { get; set; }
        public string created_ip { get; set; }
        public Int16?  newsletter { get; set; }
        public byte? welcome { get; set; }
        public string aux2 { get; set; }
        public long? language_id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public long? city_id { get; set; }
        public long? province_id { get; set; }
        public long? country_id { get; set; }
        public string postal_code { get; set; }
        public string primary_phone { get; set; }
        public string cell_phone { get; set; }
        public string profile_picture { get; set; }
        public long? account_level_id { get; set; }
        public string title { get; set; }
        public string organization { get; set; }
        public string support_email { get; set; }
        public DateTime? dob { get; set; }
        public long? height { get; set; }
        public long? weight { get; set; }
        public string shot { get; set; }
        public string catches { get; set; }
        public string position { get; set; }
        public string team { get; set; }
        public string gender { get; set; }
        public string division { get; set; }
        public Int32? height_format { get; set; }
        public Int32? weight_format { get; set; }
        public Int32? user_verified_dob { get; set; }
        public string aux1 { get; set; }
        public string other { get; set; }
        public string datastore { get; set; }
        public string st_api_key { get; set; }
        public Int32? trainer_id { get; set; }
        public string app_key { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        //public virtual Participants Participants { get; set; }
       // public  Participants Participants { get; set; }
    }
}
