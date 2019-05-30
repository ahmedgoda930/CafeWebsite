using CafeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CafeWebsite.Controllers
{
    public class MenuCatController : Controller
    {
        // GET: MenuCat
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.MenuCats.ToList());
        }

        // GET: MenuCat/Details/5
        public ActionResult Details(int?  id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuCat mc = db.MenuCats.Find(id);
            if (mc == null)
            {
                return HttpNotFound();
            }
            return View(mc);
        }

        // GET: MenuCat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuCat/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuCat form)
        {
            if (ModelState.IsValid)
            {
                db.MenuCats.Add(form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: MenuCat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuCat mc = db.MenuCats.Find(id);
            if (mc == null)
            {
                return HttpNotFound();
            }
            return View(mc);
        }

        // POST: MenuCat/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuCat form)
        {
            if (ModelState.IsValid)
            {
                db.Entry(form).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: MenuCat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuCat mc = db.MenuCats.Find(id);
            if (mc == null)
            {
                return HttpNotFound();
            }
            return View(mc);
        }

        // POST: MenuCat/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                MenuCat mc = db.MenuCats.Find(id);
                db.MenuCats.Remove(mc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
