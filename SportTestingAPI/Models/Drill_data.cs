using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Models
{
    public class Drill_data
    {
        public long id { get; set; }

        public long? combine_id { get; set; }
        public long? drill_id { get; set; }
        public long? sport_id { get; set; }
        public string capture_system { get; set; }
        public string capture_id { get; set; }
        public long? user_id { get; set; }
        public long? athlete_age { get; set; }
        public long? attempt { get; set; }
        public Double? total { get; set; }
        public Double? result_1 { get; set; }
        public Double? result_2 { get; set; }
        public Double? result_3 { get; set; }
        public Double? result_4 { get; set; }
        public Double? result_5 { get; set; }
        public Double? result_6 { get; set; }
        public Double? result_7 { get; set; }
        public Double? result_8 { get; set; }
        public Double? result_9 { get; set; }
        public string dir_1 { get; set; }
        public byte? is_certified { get; set; }
        public Int16? is_comparable { get; set; }
        public byte? dq_flag { get; set; }
        public DateTime? test_date { get; set; }
        public Int16? verified { get; set; }
        public DateTime? capture_time { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }




    }
}
