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
using LabManagementWeb.DAL;
using LabManagementWeb.Models;
using Zen.Barcode;

namespace LabManagementWeb.Controllers
{
    public class SamplesController : Controller
    {
        private ISamplesRepository samplesRepository;

        public SamplesController()
        {
            this.samplesRepository = new SamplesRespository(new ApplicationDbContext());
        }

        // GET: Samples
        public ActionResult Index()
        {
            var samples = from s in samplesRepository.GetSamples()
                          select s;
            return View(samples.ToList());
        }

        // GET: Samples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = samplesRepository.GetSampleByID(id);
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
                samplesRepository.InsertSample(sample);
                samplesRepository.Save();
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
            Sample sample = samplesRepository.GetSampleByID(id);
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
                samplesRepository.UpdateSample(sample);
                samplesRepository.Save();
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
            Sample sample = samplesRepository.GetSampleByID(id);
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
            Sample sample = samplesRepository.GetSampleByID(id);
            samplesRepository.DeleteSample(id);
            samplesRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                samplesRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
