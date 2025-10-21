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
    public class MatchManager : IMatchService
    {
        private readonly IMatchDal _dal;

        public MatchManager(IMatchDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Matchs entity)
        {
           _dal.Add(entity);
        }

        public void TDelete(Matchs entity)
        {
            _dal.Delete(entity);
        }

        public List<Matchs> TGet4UpcomingMatchEvent()
        {
           return _dal.Get4UpcomingMatchEvent();
        }

        public Matchs TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Matchs> TGetListAll()
        {
            return _dal.GetListAll();
        }

        public List<Matchs> TGetMatchListWithTeamName()
        {
           return _dal.GetMatchListWithTeamName();
        }

        public List<Matchs> TGetUpcomingMatchEvent()
        {
            return _dal.GetUpcomingMatchEvent();
        }

        public void TUpdate(Matchs entity)
        {
            _dal.Update(entity);
        }
    }
}
