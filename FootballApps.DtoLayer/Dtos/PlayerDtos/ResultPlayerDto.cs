using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApps.DtoLayer.Dtos.PlayerDtos
{
    public class ResultPlayerDto
    {
        public int PlayerId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int ShirtNumber { get; set; }
        public string PhotoUrl { get; set; }
        public string PlayerVideoUrl { get; set; }
        public int Goals { get; set; }
        public int TeamId { get; set; }
    }
}
