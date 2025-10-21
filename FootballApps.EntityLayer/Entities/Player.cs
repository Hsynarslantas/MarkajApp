using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApps.EntityLayer.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int ShirtNumber { get; set; }
        public string PhotoUrl { get; set; }
        public string PlayerVideoUrl { get; set; }
        public int  Goals { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
