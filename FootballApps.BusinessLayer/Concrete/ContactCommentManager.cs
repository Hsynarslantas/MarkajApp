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
    public class ContactCommentManager : IContactCommentService
    {
        private readonly IContactCommentDal _dal;

        public ContactCommentManager(IContactCommentDal dal)
        {
            _dal = dal;
        }

        public void TAdd(ContactComment entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(ContactComment entity)
        {
            _dal.Delete(entity);
        }

        public ContactComment TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<ContactComment> TGetListAll()
        {
            return _dal.GetListAll();
        }

        public void TUpdate(ContactComment entity)
        {
            _dal.Update(entity); 
        }
    }
}
