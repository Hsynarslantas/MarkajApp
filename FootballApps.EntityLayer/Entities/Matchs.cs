using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApps.EntityLayer.Entities
{
    public class Matchs
    {
        public int MatchsId { get; set; }
        public DateTime MatchsDate { get; set; }
        public string Stadium { get; set; }
        public string League { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public ICollection<PlayerMatchStatistic> PlayerStatistics { get; set; }
    }
}
