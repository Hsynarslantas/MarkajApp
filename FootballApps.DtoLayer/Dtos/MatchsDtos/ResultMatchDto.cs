using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApps.DtoLayer.Dtos.MatchsDtos
{
    public class ResultMatchDto
    {
        public int MatchsId { get; set; }
        public DateTime MatchsDate { get; set; }
        public string Stadium { get; set; }
        public string League { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
      
    }
}
