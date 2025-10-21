using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApps.BusinessLayer.Abstract;
using FootballApps.DataAccessLayer.Abstract;
using FootballApps.EntityLayer.Entities;

namespace FootballApps.BusinessLayer.Concrete
{
    public class PlayerManager : IPlayerService
    {
        private readonly IPlayerDal _dal;

        public PlayerManager(IPlayerDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Player entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Player entity)
        {
            _dal.Delete(entity);
        }

        public Player TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Player> TGetListAll()
        {
            return _dal.GetListAll();
        }

        public List<Player> TGetMostGoal5Players()
        {
            return _dal.GetMostGoal5Players();
        }

        public List<Player> TGetStarPlayers()
        {
           return _dal.GetStarPlayers();
        }

        public void TUpdate(Player entity)
        {
            _dal.Update(entity);
        }
    }
}
