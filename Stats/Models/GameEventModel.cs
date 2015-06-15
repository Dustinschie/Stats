using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stats.Models
{
    public class GameEventModel
    {
        [Required]
        public int GameID { get; set; }
        [Required]
        public int PlayerID { get; set; }
        [Required]
        public int PointValue { get; set; }
    }
}