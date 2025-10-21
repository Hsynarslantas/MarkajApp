using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApps.DataAccessLayer.Abstract;
using FootballApps.DataAccessLayer.Concrete;
using FootballApps.DataAccessLayer.Repositories;
using FootballApps.EntityLayer.Entities;

namespace FootballApps.DataAccessLayer.EntityFramework
{
    public class EfTeamDal : GenericRepository<Team>, ITeamDal
    {
        public EfTeamDal(FootballAppContext context) : base(context)
        {
        }

        public Team GetMaxDrawByTeam()
        {
            using (var context = new FootballAppContext())
            {
                var teamWithMostDraws = context.Teams
                    .OrderByDescending(x => x.Draw)
                    .FirstOrDefault();

                return teamWithMostDraws;
            }
        }

        public List<Team> GetMaxPointByTeam()
        {
            using var context = new FootballAppContext();
            return context.Teams.OrderBy(x=>x.TeamId).Take(1).ToList();
        }

        public List<Team> GetMinPointByTeam()
        {
            using var context = new FootballAppContext();
            return context.Teams.Where(x=>x.Point==3).ToList();
        }

        public Team GetTeamWithMostLosses()
        {
            using var context = new FootballAppContext();

            var teamWithMostLosses = context.Teams
                .OrderByDescending(x => x.Lose) 
                .FirstOrDefault();

            return teamWithMostLosses;
        }

        public List<Team> GetTeamWithPoints()
        {
            using var context= new FootballAppContext();
            return context.Teams.OrderByDescending(x=>x.Point).ToList();
        }
    }
}
