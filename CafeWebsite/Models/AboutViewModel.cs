using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class AboutViewModel
    {
        public AboutUs AboutUS { get; set; }
        public List<Chef> Chefs { get; set; }
    }
}