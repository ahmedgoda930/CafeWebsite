using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class StudioCat
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Studio> Studios { get; set; }
    }
}