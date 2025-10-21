using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApps.DtoLayer.Dtos.LatestNewDtos
{
    public class CreateLatestNewDto
    {
        public string Title { get; set; }
        public string Writer { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public string WriterImageUrl { get; set; }
    }
}
