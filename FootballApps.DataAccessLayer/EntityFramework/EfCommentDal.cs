using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApps.DataAccessLayer.Abstract;
using FootballApps.DataAccessLayer.Concrete;
using FootballApps.DataAccessLayer.Repositories;
using FootballApps.EntityLayer.Entities;

namespace FootballApps.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public EfCommentDal(FootballAppContext context) : base(context)
        {
        }

        public List<Comment> GetCommentsByBlogId(int blogId)
        {
            using (var c = new FootballAppContext())
            {
                return c.Comment
                    .Where(x => x.BlogId == blogId)
                    .ToList();
            }
        }
    }
}
