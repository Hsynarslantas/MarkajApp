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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _dal;

        public BlogManager(IBlogDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Blog entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Blog entity)
        {
            _dal.Delete(entity);
        }

        public Blog TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Blog> TGetListAll()
        {
          return _dal.GetListAll();
        }

        public void TUpdate(Blog entity)
        {
           _dal.Update(entity);
        }
    }
}
