using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApps.EntityLayer.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Writer { get; set; }
        public string WriterImageUrl { get; set; }
        public string WriterDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
