using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Models
{
    public class Athlete_metrics
    {

        public long id { get; set; }
        public string name { get; set; }
        public string format { get; set; }
        public Int16? active { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

    }
}
