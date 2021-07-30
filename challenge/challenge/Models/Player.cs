using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Player
    {
        [Key]
        public int playerId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string playerName { get; set; }
        public string solution { get; set; }
        public string result { get; set; }        

    }
}
