using CafeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeWebsite.Controllers
{
    public class NotificationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Notification
        public ActionResult Index()
        {
            NotificationViewModel notify = new Models.NotificationViewModel()
            {
                Contacts = db.Contacts.ToList(),
                Subscribes = db.Subscribes.ToList()
            };
            return View(notify);
        }
    }
}