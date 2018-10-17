using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Models
{
    public class Combine_metrics
    {
        public long id { get; set; }
        public long? combine_id { get; set; }
        public long? athlete_metric_id { get; set; }
        public long? athlete_id { get; set; }
        public string value { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }


    }
}
