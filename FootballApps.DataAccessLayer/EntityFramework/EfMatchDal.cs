using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApps.DataAccessLayer.Abstract;
using FootballApps.DataAccessLayer.Concrete;
using FootballApps.DataAccessLayer.Repositories;
using FootballApps.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballApps.DataAccessLayer.EntityFramework
{
    public class EfMatchDal : GenericRepository<Matchs>, IMatchDal
    {
        public EfMatchDal(FootballAppContext context) : base(context)
        {
        }

        public List<Matchs> Get4UpcomingMatchEvent()
        {
            using var context = new FootballAppContext();
            return context.Matches.OrderByDescending(x=>x.MatchsId).Take(4).Include(m => m.HomeTeam)
            .ThenInclude(t => t.Players)
        .Include(m => m.AwayTeam)
            .ThenInclude(t => t.Players)
        .ToList();
        }

        public List<Matchs> GetMatchListWithTeamName()
        {
            using (var context = new FootballAppContext())
            {
                return context.Matches.Where(x=>x.MatchsId==1)
            .Include(m => m.HomeTeam)
                .ThenInclude(t => t.Players)
            .Include(m => m.AwayTeam)
                .ThenInclude(t => t.Players)
            .Include(m => m.PlayerStatistics) 
            .ToList();
            } ;

        }

        public List<Matchs> GetUpcomingMatchEvent()
        {
            using var context = new FootballAppContext();
            return context.Matches
        .Where(x => x.MatchsId == 2)
        .Include(m => m.HomeTeam)
            .ThenInclude(t => t.Players)
        .Include(m => m.AwayTeam)
            .ThenInclude(t => t.Players)   
        .ToList();
        }
    }
}
