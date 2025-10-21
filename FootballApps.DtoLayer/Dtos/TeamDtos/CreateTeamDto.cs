using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApps.DtoLayer.Dtos.TeamDtos
{
    public class CreateTeamDto
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string CoachName { get; set; }
        public decimal Point { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }
    }
}
