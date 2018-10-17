using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Models
{
    public class Sports
    {
        public long id { get; set; }
        public string name { get; set; }
        public string display_name { get; set; }

        public byte? status { get; set; }
    }
}
