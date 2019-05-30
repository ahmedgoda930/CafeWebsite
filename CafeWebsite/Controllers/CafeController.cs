using CafeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CafeWebsite.Controllers
{
    [AllowAnonymous]
    public class CafeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cafe
        public ActionResult MainPage()
        {
            return View();
        }
        public ActionResult About()
        {
            AboutViewModel about = new Models.AboutViewModel()
            {
                AboutUS = db.AboutUs.Find(3),
                Chefs = db.Chefs.ToList()
            };
            return View(about);
        }

        public ActionResult Menu()
        {
            List<MenuCat> catlst = db.MenuCats.ToList();
            List<Menu> Menulst = db.Menus.ToList();
            var lst = catlst.Join(Menulst, cat => cat.ID, menu => menu.FK_CatID, 
                (c, m) => new { c, m }).Select(z => new { z.c.Name, z.m.PName, z.m.Price, z.m.Content });
            var group = (from m in lst group m by m.Name).ToList();
            //List<MenuViewModel> menu = new List<Models.MenuViewModel>();
            //menu = group.ToList();
            return View(group);
        }

        public ActionResult BlogsPage()
        {
            return View(db.Blogs.ToList());
        }
        public ActionResult MaindDishesPage()
        {
            return View(db.MainDishes.ToList());
        }

        public ActionResult StudioPage()
        {
            List<Studio> stdlst = db.Studios.ToList();
            List<StudioViewModel> stdVMlst = stdlst.Select(
                x => new Models.StudioViewModel
                {
                    ID = x.ID,
                    Name = x.StudioCat.Name,
                    FK_CatID = x.FK_CatID,
                    URL = x.URL
                }).ToList();
            return View(stdVMlst);
        }

        public ActionResult BlogDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogs blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public void Subscribe(Subscribes Form)
        {
            if (ModelState.IsValid)
            {
                db.Subscribes.Add(Form);
                db.SaveChanges();
            }
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contacts form)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(form);
                db.SaveChanges();
                ViewBag.MSG = "Send";
            }
            return View();
        }
    }
}