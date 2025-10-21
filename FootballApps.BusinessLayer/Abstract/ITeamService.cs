using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApps.EntityLayer.Entities;

namespace FootballApps.BusinessLayer.Abstract
{
    public interface ITeamService : IGenericService<Team>
    {
        List<Team> TGetTeamWithPoints();
        List<Team> TGetMaxPointByTeam();
        List<Team> TGetMinPointByTeam();
        Team TGetTeamWithMostLosses();
        Team TGetMaxDrawByTeam();
    }
}
