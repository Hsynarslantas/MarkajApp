using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApps.EntityLayer.Entities
{
    public class LatestNew
    {
        public int LatestNewId { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public string WriterImageUrl { get; set; }

    }
}
