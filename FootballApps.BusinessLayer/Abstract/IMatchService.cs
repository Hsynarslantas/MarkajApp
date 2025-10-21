using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApps.EntityLayer.Entities;

namespace FootballApps.BusinessLayer.Abstract
{
    public interface IMatchService : IGenericService<Matchs>
    {
        List<Matchs> TGetMatchListWithTeamName();
        List<Matchs> TGetUpcomingMatchEvent();
        List<Matchs> TGet4UpcomingMatchEvent();
    }
}
