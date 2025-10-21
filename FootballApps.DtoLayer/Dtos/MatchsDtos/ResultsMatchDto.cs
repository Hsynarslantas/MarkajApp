using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApps.DtoLayer.Dtos.PlayerMatchStatisticsDtos;

namespace FootballApps.DtoLayer.Dtos.MatchsDtos
{
    public class ResultsMatchDto
    {
        public int MatchsId { get; set; }
        public DateTime MatchsDate { get; set; }
        public string Stadium { get; set; }
        public string League { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public TeamDto HomeTeam { get; set; }
        public TeamDto AwayTeam { get; set; }


        public List<PlayerMatchStatisticDto> PlayerStatistics { get; set; }
    }
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string CoachName { get; set; }
        public List<PlayerDto> Players { get; set; }
    }
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string FullName { get; set; }
        public int ShirtNumber { get; set; }
    }
    public class PlayerMatchStatisticDto
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int MatchsId { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int GoalMinutes { get; set; }
    }
}
