using CafeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CafeWebsite.Controllers
{
    public class NotificationViewModelController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Contacts
        public ActionResult Index()
        {
            NotificationViewModel notify = new NotificationViewModel()
            {
                Contacts = db.Contacts.ToList(),
                Subscribes = db.Subscribes.ToList()
            };
            return View(notify);
        }

        // GET: Contacts/Details/5
        public ActionResult ContactsDetails(int? id)      
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts cont = db.Contacts.Find(id);
            if (cont == null)
            {
                return  HttpNotFound();
            }
            return View(cont);
        }
    }
}
