using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabManagementWeb.Models;

namespace LabManagementWeb.Controllers
{
    public class SamplesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Samples
        public ActionResult Index()
        {
            return View(db.Samples.ToList());
        }

        // GET: Samples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // GET: Samples/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Samples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SampleID,Weight,Job_ID,DateCreated,UserCreated,DateModified,UserModified")] Sample sample)
        {
            if (ModelState.IsValid)
            {
                db.Samples.Add(sample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sample);
        }

        // GET: Samples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // POST: Samples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SampleID,Weight,Job_ID,DateCreated,UserCreated,DateModified,UserModified")] Sample sample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sample);
        }

        // GET: Samples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // POST: Samples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sample sample = db.Samples.Find(id);
            db.Samples.Remove(sample);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Barcode(int id)
        {
            Sample sample = db.Samples.Find(id);
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap bitMap = new Bitmap(sample.SampleID.ToString().Length * 40, 80))
                {
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        Font oFont = new Font("~/fonts/free3of9.ttf", 16);
                        PointF point = new PointF(2f, 2f);

                        SolidBrush whitebrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whitebrush, 0, 0, bitMap.Width, bitMap.Height);

                        SolidBrush blackbrush = new SolidBrush(Color.Black);
                        graphics.DrawString("*" + sample.SampleID.ToString() + "*", oFont, blackbrush, point); 
                    }
                    bitMap.Save(ms, ImageFormat.Png);

                    ViewBag.BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
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
