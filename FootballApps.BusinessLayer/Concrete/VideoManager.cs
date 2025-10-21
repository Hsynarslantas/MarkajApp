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
    public class VideoManager : IVideoService
    {
        private readonly IVideoDal _dal;

        public VideoManager(IVideoDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Video entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Video entity)
        {
            _dal.Delete(entity);
        }

        public Video TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Video> TGetListAll()
        {
            return _dal.GetListAll();
        }

        public void TUpdate(Video entity)
        {
            _dal.Update(entity);
        }
    }
}
