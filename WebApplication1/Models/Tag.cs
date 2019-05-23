using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCompany.Models
{
    public class Tag
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GameCompanyID { get; set; }
    }
}
