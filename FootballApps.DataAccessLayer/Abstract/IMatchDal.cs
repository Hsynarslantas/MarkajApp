using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApps.EntityLayer.Entities;

namespace FootballApps.DataAccessLayer.Abstract
{
    public interface IMatchDal:IGenericDal<Matchs>
    {
        List<Matchs> GetMatchListWithTeamName();
        List<Matchs> GetUpcomingMatchEvent();

        List<Matchs> Get4UpcomingMatchEvent();
    }
}
