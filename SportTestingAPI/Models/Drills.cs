using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Models
{
    public class Drills
    {
        public long id { get; set; }
        public long? user_id { get; set; }
        public Int32 drill_set { get; set; }
        public string name { get; set; }
        public string display_name { get; set; }
        public string description { get; set; }
        public string sport { get; set; }
        public long? sport_id { get; set; }
        public string input { get; set; }
        public Int32? checkpoints { get; set; }
        public Int32? splits { get; set; }
        public string splits_direction { get; set; }

        public string qualifier { get; set; }
        public string units { get; set; }

        public Single? max_total { get; set; }
        public Single? min_total { get; set; }
        public Int32? display_order { get; set; }
        public string format { get; set; }

        public Int16? archived { get; set; }

        public Int32? conversion_drill_id { get; set; }
        public string download { get; set; }
        public Int32? correlation_id { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }



    }
}

