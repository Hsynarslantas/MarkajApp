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
    public class PlayerMatchStatisticManager : IPlayerMatchStatisticService
    {
        private readonly IPlayerMatchStatisticDal _dal;

        public PlayerMatchStatisticManager(IPlayerMatchStatisticDal dal)
        {
            _dal = dal;
        }

        public void TAdd(PlayerMatchStatistic entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(PlayerMatchStatistic entity)
        {
            _dal.Delete(entity);
        }

        public PlayerMatchStatistic TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<PlayerMatchStatistic> TGetListAll()
        {
            return _dal.GetListAll();
        }

        public void TUpdate(PlayerMatchStatistic entity)
        {
            _dal.Update(entity);
        }
    }
}
