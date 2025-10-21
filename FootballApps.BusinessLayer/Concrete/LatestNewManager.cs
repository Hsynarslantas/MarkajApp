
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
    public class LatestNewManager : ILatestNewService
    {
        private readonly ILatestNewDal _dal;

        public LatestNewManager(ILatestNewDal dal)
        {
            _dal = dal;
        }

        public void TAdd(LatestNew entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(LatestNew entity)
        {
            _dal.Delete(entity);
        }

        public LatestNew TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<LatestNew> TGetListAll()
        {
            return _dal.GetListAll();
        }

        public void TUpdate(LatestNew entity)
        {
            _dal.Update(entity);
        }
    }
}
