using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabManagementWeb.DAL;
using LabManagementWeb.Models;

namespace LabManagementWeb.Controllers
{
    public class JobTypesController : Controller
    {
        private IJobTypesRepository jobTypesRepository;

        public JobTypesController()
        {
            this.jobTypesRepository = new JobTypesRepository(new ApplicationDbContext());
        }
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobTypes
        [Authorize]
        public ActionResult Index()
        {
            var jobTypes = from j in jobTypesRepository.GetJobTypes()
                           select j;
            return View(jobTypes.ToList());
            //return View(db.JobTypes.ToList());
        }

        // GET: JobTypes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobType jobType = jobTypesRepository.GetJobTypeByID(id);
            //JobType jobType = db.JobTypes.Find(id);
            if (jobType == null)
            {
                return HttpNotFound();
            }
            return View(jobType);
        }

        // GET: JobTypes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Description,Prefix,DateCreated,UserCreated,DateModified,UserModified")] JobType jobType)
        {
            if (ModelState.IsValid)
            {
                //db.JobTypes.Add(jobType);
                //db.SaveChanges();
                jobTypesRepository.InsertJobType(jobType);
                jobTypesRepository.Save();
                return RedirectToAction("Index");
            }

            return View(jobType);
        }

        // GET: JobTypes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobType jobType = jobTypesRepository.GetJobTypeByID(id);
            //JobType jobType = db.JobTypes.Find(id);
            if (jobType == null)
            {
                return HttpNotFound();
            }
            return View(jobType);
        }

        // POST: JobTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,Description,Prefix,DateCreated,UserCreated,DateModified,UserModified")] JobType jobType)
        {
            if (ModelState.IsValid)
            {
                jobTypesRepository.UpdateJobType(jobType);
                jobTypesRepository.Save();
                //db.Entry(jobType).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobType);
        }

        // GET: JobTypes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobType jobType = jobTypesRepository.GetJobTypeByID(id);
            //JobType jobType = db.JobTypes.Find(id);
            if (jobType == null)
            {
                return HttpNotFound();
            }
            return View(jobType);
        }

        // POST: JobTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            JobType jobType = jobTypesRepository.GetJobTypeByID(id);
            jobTypesRepository.DeleteJobType(id);
            jobTypesRepository.Save();
            //JobType jobType = db.JobTypes.Find(id);
            //db.JobTypes.Remove(jobType);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                jobTypesRepository.Dispose();
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
