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
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _dal;

        public TeamManager(ITeamDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Team entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Team entity)
        {
            _dal.Delete(entity);
        }

        public Team TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Team> TGetListAll()
        {
            return _dal.GetListAll();
        }

        public Team TGetMaxDrawByTeam()
        {
            return _dal.GetMaxDrawByTeam();
        }

        public List<Team> TGetMaxPointByTeam()
        {
           return _dal.GetMaxPointByTeam();
        }

        public List<Team> TGetMinPointByTeam()
        {
           return _dal.GetMinPointByTeam();
        }

        public Team TGetTeamWithMostLosses()
        {
            return _dal.GetTeamWithMostLosses();
        }

        public List<Team> TGetTeamWithPoints()
        {
           return _dal.GetTeamWithPoints();
        }

        public void TUpdate(Team entity)
        {
            _dal.Update(entity);
        }
    }
}
