using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Models
{
    public class Combines
    {
        public long id { get; set; }
        public Int32? user_id { get; set; }
        public Int32? combine_id { get; set; }
        public long? location_id { get; set; }
        public long? sport_id { get; set; }
        public string combine_logo { get; set; }
        public DateTime? combine_date { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public Single? admission_cost { get; set; }
        public Single? tax_amount { get; set; }
        public string age_restriction { get; set; }
        public byte? age_group_from { get; set; }
        public byte? age_group_to { get; set; }
        public Int32? age_average { get; set; }
        public Int32? approved { get; set; }
        public string name { get; set; }
        public Int32? joinable { get; set; }
        public string template_group { get; set; }
        public Int16? allow_csv { get; set; }
        public Int16? allow_pdf { get; set; }
        public Int16? allow_attempt { get; set; }
        public Int16? pdf_drill_group { get; set; }
        public Int16? separate_positions { get; set; }
        public Int16? rankings { get; set; }
        public Int16? tally { get; set; }
        public string athlete_fields { get; set; }
        public string order_field{ get; set; }
        public string order_direction { get; set; }
        public string aux_field_1_title { get; set; }
        public string aux_field_2_title { get; set; }
        public string required_positions { get; set; }
        public Int16? locked { get; set; }
        public Int16? archived { get; set; }
        public byte? hide_results { get; set; }
        public Int32? coach_email_id { get; set; }
        public Int32? athlete_email_id { get; set; }
        public string access_code { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }




    }
}
