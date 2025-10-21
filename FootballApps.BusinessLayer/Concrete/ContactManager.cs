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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _dal;

        public ContactManager(IContactDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Contact entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            _dal.Delete(entity);
        }

        public Contact TGetById(int id)
        {
          return _dal.GetById(id);
        }

        public List<Contact> TGetListAll()
        {
           return _dal.GetListAll();
        }

        public void TUpdate(Contact entity)
        {
            _dal.Update(entity);
        }
    }
}
