using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MI138_GroupProject.Models
{
    public class ReviewVM
    {
        public int GameID { get; set; }
        public string Content { get; set; }
        public bool Positive { get; set; }
    }
}