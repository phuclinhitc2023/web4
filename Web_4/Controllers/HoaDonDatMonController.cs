using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_4.Models;

namespace Web_4.Controllers
{
    public class HoaDonDatMonController : Controller
    {
        private QLQuanAnEntities db = new QLQuanAnEntities();

        // GET: HoaDonDatMon
        public ActionResult Index(string tenKH)
        {
            var hoaDonDatMons = db.HoaDonDatMons.Include(h => h.KhachHang).Include(h => h.MonAn);
            if (!string.IsNullOrEmpty(tenKH)) hoaDonDatMons = hoaDonDatMons.Where(hd => hd.KhachHang.HoTen.ToLower().Contains(tenKH.Trim().ToLower()));
            return View(hoaDonDatMons.ToList());
        }

        // GET: HoaDonDatMon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDatMon hoaDonDatMon = db.HoaDonDatMons.Find(id);
            if (hoaDonDatMon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonDatMon);
        }

        // GET: HoaDonDatMon/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen");
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon");
            return View();
        }

        // POST: HoaDonDatMon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaMon,MaKH,NgayDat,SoLuong")] HoaDonDatMon hoaDonDatMon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonDatMons.Add(hoaDonDatMon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", hoaDonDatMon.MaKH);
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDonDatMon.MaMon);
            return View(hoaDonDatMon);
        }

        // GET: HoaDonDatMon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDatMon hoaDonDatMon = db.HoaDonDatMons.Find(id);
            if (hoaDonDatMon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", hoaDonDatMon.MaKH);
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDonDatMon.MaMon);
            return View(hoaDonDatMon);
        }

        // POST: HoaDonDatMon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaMon,MaKH,NgayDat,SoLuong")] HoaDonDatMon hoaDonDatMon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonDatMon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", hoaDonDatMon.MaKH);
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDonDatMon.MaMon);
            return View(hoaDonDatMon);
        }

        // GET: HoaDonDatMon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDatMon hoaDonDatMon = db.HoaDonDatMons.Find(id);
            if (hoaDonDatMon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonDatMon);
        }

        // POST: HoaDonDatMon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDonDatMon hoaDonDatMon = db.HoaDonDatMons.Find(id);
            db.HoaDonDatMons.Remove(hoaDonDatMon);
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
