using CafeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CafeWebsite.Controllers
{
    public class MenuController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            ViewBag.Cat = new SelectList(db.MenuCats.ToList(),"ID","Name");
            return View();
        }
        public JsonResult GetMenu(int id)
        {
            List<Menu> lst = db.Menus.Where(x => x.FK_CatID == id).ToList();
            ViewBag.COUNT = lst.Count();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        // GET: Menu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu mn = db.Menus.Find(id);
            if (mn == null)
            {
                return HttpNotFound();
            }
            return View(mn);
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            ViewBag.Cat = new SelectList(db.MenuCats.ToList(), "ID", "Name");
            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Menu form)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu mn = db.Menus.Find(id);
            if (mn == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cat = new SelectList(db.MenuCats.ToList(), "ID", "Name");
            return View(mn);
        }

        // POST: Menu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu form)
        {
            if (ModelState.IsValid)
            {
                db.Entry(form).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu mn = db.Menus.Find(id);
            if (mn == null)
            {
                return HttpNotFound();
            }
            return View(mn);
        }

        // POST: Menu/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            if (ModelState.IsValid)
            {
                Menu mn = db.Menus.Find(id);
                db.Menus.Remove(mn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
