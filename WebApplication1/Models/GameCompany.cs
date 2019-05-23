using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCompany.Models
{
    public class GameCompany
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Tag> Tag { get; set; }
        public DateTime Created { get; set; }
        public string ScreenshotUrl { get; set; }
        public string Developer { get; set; }
        public bool Published { get; set; }
    }
}
