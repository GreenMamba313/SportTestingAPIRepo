using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Models
{
    public class Combine_athlete_metrics
    {
        public long id { get; set; }
        public long? combine_id { get; set; }
        public long? athlete_metric_id { get; set; }
        public byte? allow_coach_report { get; set; }
        public byte? allow_athlete_report { get; set; }

    }
}
