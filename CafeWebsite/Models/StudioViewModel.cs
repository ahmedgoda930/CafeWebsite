using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class StudioViewModel
    {
        public int ID { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public int FK_CatID { get; set; }
        //public List<Studio> Studios { get; set; }
        //public List<StudioCat> StudioCategories { get; set; } 
    }
}