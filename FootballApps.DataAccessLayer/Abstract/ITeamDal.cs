using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApps.EntityLayer.Entities;

namespace FootballApps.DataAccessLayer.Abstract
{
    public interface ITeamDal:IGenericDal<Team>
    {
        List<Team> GetTeamWithPoints();

        List<Team> GetMaxPointByTeam();
        List<Team> GetMinPointByTeam();

        Team GetMaxDrawByTeam();
        Team GetTeamWithMostLosses();
    }
}
