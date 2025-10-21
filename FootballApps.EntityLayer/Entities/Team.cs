using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballApps.EntityLayer.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string CoachName { get; set; }
        public decimal Point { get; set; }
        public int  Win { get; set; }
        public int  Draw { get; set; }
        public int  Lose { get; set; }

        public ICollection<Player> Players { get; set; }
        public ICollection<Matchs> HomeMatches { get; set; }
        public ICollection<Matchs> AwayMatches { get; set; }
    }
}
