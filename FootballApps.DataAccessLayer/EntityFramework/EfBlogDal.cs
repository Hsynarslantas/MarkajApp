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
    public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {
        public EfBlogDal(FootballAppContext context) : base(context)
        {
        }
    }
}
