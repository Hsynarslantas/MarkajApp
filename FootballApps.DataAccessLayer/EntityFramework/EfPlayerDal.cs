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
    public class EfPlayerDal : GenericRepository<Player>, IPlayerDal
    {
        public EfPlayerDal(FootballAppContext context) : base(context)
        {
        }

        public List<Player> GetMostGoal5Players()
        {
            using var context = new FootballAppContext();
            return context.Players.OrderByDescending(x=>x.Goals).Take(8).ToList();
        }

        public List<Player> GetStarPlayers()
        {
            using var context = new FootballAppContext();
            var names = new List<string>
    {
        "Cristiano Ronaldo",
        "Lionel Messi",
        "Kylian Mbappe",
        "Neymar Jr",
        "Erling Haaland"
    };

            var players = context.Players
                .Where(x => names.Contains(x.FullName))
                .ToList();

            return players;
        }
    }
}
