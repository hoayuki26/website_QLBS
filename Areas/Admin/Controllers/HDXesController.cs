using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using finaltest.Areas.Admin.Models;

namespace finaltest.Areas.Admin.Controllers
{
    public class HDXesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/HDXes
        public ActionResult Index()
        {
            return View(db.HDXes.ToList());
        }

        // GET: Admin/HDXes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDX hDX = db.HDXes.Find(id);
            if (hDX == null)
            {
                return HttpNotFound();
            }
            return View(hDX);
        }

        // GET: Admin/HDXes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HDXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaKH,MaSP,SL,NgayBan,Tongtien")] HDX hDX)
        {
            if (ModelState.IsValid)
            {
                db.HDXes.Add(hDX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hDX);
        }

        // GET: Admin/HDXes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDX hDX = db.HDXes.Find(id);
            if (hDX == null)
            {
                return HttpNotFound();
            }
            return View(hDX);
        }

        // POST: Admin/HDXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaKH,MaSP,SL,NgayBan,Tongtien")] HDX hDX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hDX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hDX);
        }

        // GET: Admin/HDXes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDX hDX = db.HDXes.Find(id);
            if (hDX == null)
            {
                return HttpNotFound();
            }
            return View(hDX);
        }

        // POST: Admin/HDXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HDX hDX = db.HDXes.Find(id);
            db.HDXes.Remove(hDX);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
