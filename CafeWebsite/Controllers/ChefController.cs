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
    public class ChefController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Chef
        public ActionResult Index()
        {
            return View(db.Chefs.ToList());
        }

        // GET: Chef/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chef chf = db.Chefs.Find(id);
            if (chf == null)
            {
                return HttpNotFound();
            }
            return View(chf);
        }

        // GET: Chef/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chef/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chef form,HttpPostedFileBase URL)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), URL.FileName);
                URL.SaveAs(path);
                form.URL = URL.FileName;
                db.Chefs.Add(form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Chef/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chef chf = db.Chefs.Find(id);
            if (chf == null)
            {
                return HttpNotFound();
            }
            return View(chf);
        }

        // POST: Chef/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Chef form, HttpPostedFileBase URL)
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

        // GET: Chef/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chef chf = db.Chefs.Find(id);
            if (chf == null)
            {
                return HttpNotFound();
            }
            return View(chf);
        }

        // POST: Chef/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Chef chf = db.Chefs.Find(id);
                db.Chefs.Remove(chf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
