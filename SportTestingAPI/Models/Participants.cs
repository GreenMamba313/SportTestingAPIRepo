using SportTestingAPI.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Models
{
    public class Participants
    {
        public long id { get; set; }
        public long? combine_id { get; set; }


        public long? user_id {get;set;}

        public string participant_type { get; set; }

        public string band_id { get; set; }
        public string rfid { get; set; }
        public Int16? preemail { get; set; }
        public Int16? postemail { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }

        public UsersDto user { get; set; }

   
    }
}
