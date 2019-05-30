using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class NotificationViewModel
    {
        public List<Contacts> Contacts { get; set; }
        public List<Subscribes> Subscribes { get; set; }
    }
}