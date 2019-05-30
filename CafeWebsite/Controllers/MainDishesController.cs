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
    public class MainDishesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: MainDishes
        public ActionResult Index()
        {
            return View(db.MainDishes.ToList());
        }

        // GET: MainDishes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainDishes md = db.MainDishes.Find(id);
            if (md == null)
            {
                return HttpNotFound();
            }
            return View(md);
        }

        // GET: MainDishes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainDishes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MainDishes form,HttpPostedFileBase URL)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), URL.FileName);
                URL.SaveAs(path);
                form.URL = URL.FileName;
                db.MainDishes.Add(form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: MainDishes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainDishes md = db.MainDishes.Find(id);
            if (md == null)
            {
                return HttpNotFound();
            }
            return View(md);
        }

        // POST: MainDishes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MainDishes form,HttpPostedFileBase URL)
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

        // GET: MainDishes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainDishes md = db.MainDishes.Find(id);
            if (md == null)
            {
                return HttpNotFound();
            }
            return View(md);
        }

        // POST: MainDishes/Delete/5
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
