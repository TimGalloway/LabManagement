﻿using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LabManagementWeb.Models;

namespace LabManagementWeb.Controllers
{
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }

        // GET: Jobs/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        [Authorize]
        public ActionResult Create()
        {
            var jobTypeList = (from jt in db.JobTypes select jt);
            ViewBag.JobTypesList = new SelectList(jobTypeList, "Id", "Description");

            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,JobNumber,SubmissionReference,BulkaBagNumber,ClientOrder,SendReportQLAB,SendReportEmail,SendReportOther,SendReportOtherDetails,Dispose,Stored,StoredUntil,ReturnedToClient,ReturnByCourier,ReturnByCourierAccnt,SampleTypeRABRC,SampleTypeMETPLANT,SampleTypeUMPIREPARTY,SampleTypePULPS,SampleTypeSOILS,SampleTypeCOREROCKS,SampleTypeSOLUTIONS,SampleTypesMMI,SampleTypeOTHER,SampleTypeOTHERDetails,DateCreated,UserCreated,DateModified,UserModified,JobType_ID")] Job job)
        {
            if (ModelState.IsValid)
            {
                job.JobType = db.JobTypes.Find(job.JobType_ID);
                db.Jobs.Add(job);
                db.SaveChanges();

                job.JobNumber = job.JobType.Prefix + job.ID;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Jobs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            var jobTypeList = (from jt in db.JobTypes select jt);
            ViewBag.JobTypesList = new SelectList(jobTypeList, "Id", "Description");

            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,JobNumber,SubmissionReference,BulkaBagNumber,ClientOrder,SendReportQLAB,SendReportEmail,SendReportOther,SendReportOtherDetails,Dispose,Stored,StoredUntil,ReturnedToClient,ReturnByCourier,ReturnByCourierAccnt,SampleTypeRABRC,SampleTypeMETPLANT,SampleTypeUMPIREPARTY,SampleTypePULPS,SampleTypeSOILS,SampleTypeCOREROCKS,SampleTypeSOLUTIONS,SampleTypesMMI,SampleTypeOTHER,SampleTypeOTHERDetails,DateCreated,UserCreated,DateModified,UserModified,JobType_ID")] Job job)
        {
            if (ModelState.IsValid)
            {
                job.JobType = db.JobTypes.Find(job.JobType_ID);
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();

                job.JobNumber = job.JobType.Prefix + job.ID;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
