using CafeWebsite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CafeWebsite.Controllers
{
    public class StudioController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Studio
        public ActionResult Index()
        {
            //var lst = from std in db.Studios join sct in db.StudioCats on std.FK_CatID equals sct.ID select new { std.ID, std.URL, sct.Name,std.FK_CatID };
            //List<StudioViewModel> nlst = lst.ToList();
            List<Studio> stdlst = db.Studios.ToList();
            List<StudioViewModel> stdVMlst = stdlst.Select(
                x => new Models.StudioViewModel {
                    ID = x.ID, Name = x.StudioCat.Name,
                    FK_CatID = x.FK_CatID, URL = x.URL }).ToList();
            return View(stdVMlst);
        }

        // GET: Studio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio std = db.Studios.Find(id);
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }

        // GET: Studio/Create
        public ActionResult Create(string id)
        {
            ViewBag.Cat = new SelectList(db.StudioCats.ToList(), "ID", "Name");
            //var vrt = from user in db.Users where user.Roles.Any(r => r.RoleId == id) && user.Id == "" select user;
            return View();
        }

        // POST: Studio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Studio form,HttpPostedFileBase URL)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), URL.FileName);
                URL.SaveAs(path);
                form.URL = URL.FileName;
                db.Studios.Add(form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Studio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio std = db.Studios.Find(id);
            if (std == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cat = new SelectList(db.StudioCats.ToList(), "ID", "Name");
            return View(std);
        }

        // POST: Studio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Studio form, HttpPostedFileBase URL)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), URL.FileName);
                URL.SaveAs(path);
                form.URL = URL.FileName;
                db.Entry(form).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Studio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio std = db.Studios.Find(id);
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }

        // POST: Studio/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                MainDishes md = db.MainDishes.Find(id);
                db.MainDishes.Remove(md);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
