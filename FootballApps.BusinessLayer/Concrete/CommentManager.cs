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
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _dal;

        public CommentManager(ICommentDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Comment entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Comment entity)
        {
           _dal.Delete(entity);
        }

        public Comment TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Comment> TGetCommentsByBlogId(int blogId)
        {
            return _dal.GetCommentsByBlogId(blogId);
        }

        public List<Comment> TGetListAll()
        {
            return _dal.GetListAll();
        }

        public void TUpdate(Comment entity)
        {
            _dal.Update(entity);
        }
    }
}
