using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Models
{
    public class Combine_drills
    {
        public long id { get; set; }
        public long? combine_id { get; set; }
        public long? drill_id { get; set; }
        public byte? display_order { get; set; }
        public Int16? display_group { get; set; }
        public byte? lanes { get; set; }

    }
}
