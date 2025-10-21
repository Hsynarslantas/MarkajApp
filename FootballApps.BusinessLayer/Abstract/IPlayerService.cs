using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApps.EntityLayer.Entities;

namespace FootballApps.BusinessLayer.Abstract
{
    public interface IPlayerService:IGenericService<Player>
    {
        List<Player> TGetStarPlayers();
        List<Player> TGetMostGoal5Players();
    }
}
