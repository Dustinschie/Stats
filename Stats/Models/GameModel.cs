using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stats.Models
{
    public class GameModel
    {
        public TeamModel HomeTeam { get; set; }
        public TeamModel AwayTeam { get; set; }
        public DateTime StartTime { get; set; }
        public int GameID { set; get; }
        public List<GameEventModel> GameEvents { get; set; }
    }
}