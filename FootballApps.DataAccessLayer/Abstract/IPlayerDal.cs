using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApps.EntityLayer.Entities;

namespace FootballApps.DataAccessLayer.Abstract
{
    public interface IPlayerDal:IGenericDal<Player>
    {
        List<Player> GetStarPlayers();

        List<Player> GetMostGoal5Players();

    }
}
