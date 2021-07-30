using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Challenges
    {
        [Key]
        public int challengeId { get; set; }
        public string description { get; set; }        
    }
}
