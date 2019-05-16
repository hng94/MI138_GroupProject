using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MI138_GroupProject.Models
{
    public class GameVM
    {
        public string Name { get; set; }
        public string ScreenshotUrl { get; set; }
        public List<string> Tags { get; set; }
        public string CreatorEmail { get; set; }
        public string CreatorPassword { get; set; }
    }
}