using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApps.EntityLayer.Entities
{
    public class PlayerMatchStatistic
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int MatchsId { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int GoalMinutes { get; set; }
        public Player Player { get; set; }
        public Matchs Matchs { get; set; }
    }
}
