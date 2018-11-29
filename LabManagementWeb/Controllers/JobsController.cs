using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LabManagementWeb.Models;
using LabManagementWeb.ViewModels;

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
            List<Sample> samples = db.Samples.Where(a => a.Job_ID == id).ToList();

            JobsSamplesViewModel jobsSamplesViewModel = new JobsSamplesViewModel();
            jobsSamplesViewModel.job = job;
            jobsSamplesViewModel.samples = samples;
            return View(jobsSamplesViewModel);
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
        public ActionResult Create([Bind(Include = "ID,JobNumber,SubmissionReference,BulkaBagNumber,ClientOrder,SendReportQLAB,SendReportEmail,SendReportOther,SendReportOtherDetails,Dispose,Stored,StoredUntil,ReturnedToClient,ReturnByCourier,ReturnByCourierAccnt,SampleTypeRABRC,SampleTypeMETPLANT,SampleTypeUMPIREPARTY,SampleTypePULPS,SampleTypeSOILS,SampleTypeCOREROCKS,SampleTypeSOLUTIONS,SampleTypesMMI,SampleTypeOTHER,SampleTypeOTHERDetails,DateCreated,UserCreated,DateModified,UserModified,JobType_ID,SampleIDStart, SampleIDEnd")] Job job)
        {
            if (ModelState.IsValid)
            {
                job.JobType = db.JobTypes.Find(job.JobType_ID);
                db.Jobs.Add(job);
                db.SaveChanges();

                job.JobNumber = job.JobType.Prefix + job.ID;
                db.SaveChanges();

                //Create samples records using SampleIDStart and SampleIDEnd
                barcodecs objBar = new barcodecs();
                for (int sampleLoop = job.SampleIDStart;sampleLoop <= job.SampleIDEnd; sampleLoop++)
                {
                    Sample newSample = new Sample
                    {
                        Job = job,
                        Job_ID = job.ID,
                        SampleID = sampleLoop,
                        BarCodeImage = Convert.ToBase64String(objBar.getBarcodeImage(sampleLoop.ToString(), sampleLoop.ToString()))
                    };
                    db.Samples.Add(newSample);
                }
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
        public ActionResult Edit([Bind(Include = "ID,JobNumber,SubmissionReference,BulkaBagNumber,ClientOrder,SendReportQLAB,SendReportEmail,SendReportOther,SendReportOtherDetails,Dispose,Stored,StoredUntil,ReturnedToClient,ReturnByCourier,ReturnByCourierAccnt,SampleTypeRABRC,SampleTypeMETPLANT,SampleTypeUMPIREPARTY,SampleTypePULPS,SampleTypeSOILS,SampleTypeCOREROCKS,SampleTypeSOLUTIONS,SampleTypesMMI,SampleTypeOTHER,SampleTypeOTHERDetails,DateCreated,UserCreated,DateModified,UserModified,JobType_ID,SampleIDStart, SampleIDEnd")] Job job)
        {
            if (ModelState.IsValid)
            {
                job.JobType = db.JobTypes.Find(job.JobType_ID);
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();

                job.JobNumber = job.JobType.Prefix + job.ID;
                db.SaveChanges();

                //Create samples records using SampleIDStart and SampleIDEnd
                for (int sampleLoop = job.SampleIDStart; sampleLoop <= job.SampleIDEnd; sampleLoop++)
                {
                    Sample newSample = new Sample
                    {
                        Job = job,
                        Job_ID = job.ID,
                        SampleID = sampleLoop
                    };
                    Sample testSample = (Sample) db.Samples.Where(a => a.SampleID == sampleLoop).FirstOrDefault<Sample>();
                    if (testSample == null)
                    {
                        db.Samples.Add(newSample);
                    }
                }
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

        // LabelsPDF
        [Authorize]
        public ActionResult LabelsPDF(int? id)
        {
            // Open a new PDF document

            const int pageMargin = 5;
            const int pageRows = 5;
            const int pageCols = 2;

            var doc = new Document();
            doc.SetMargins(pageMargin, pageMargin, pageMargin, pageMargin);
            var memoryStream = new MemoryStream();

            var pdfWriter = PdfWriter.GetInstance(doc, memoryStream);
            doc.Open();

            PdfPTable table = new PdfPTable(pageCols);
            table.WidthPercentage = 100f;
            table.DefaultCell.Border = 0;

            var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

            var samples = (from s in db.Samples
                           where s.Job_ID == id
                           select s).ToList();
            foreach (var sample in samples)
            {
                PdfPCell cell = new PdfPCell();
                cell.Border = 0;
                cell.FixedHeight = (doc.PageSize.Height - (pageMargin * 2)) / pageRows;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                var contents = new Paragraph();
                contents.Alignment = Element.ALIGN_CENTER;

                byte[] imageBytes = Convert.FromBase64String(sample.BarCodeImage);
                Image image = Image.GetInstance(imageBytes);
                contents.Add(image);

                //contents.Add(new Chunk(string.Format("Thing #{0}\n", sample.SampleID), new Font(baseFont, 11f, Font.BOLD)));
                contents.Add(new Chunk(string.Format("Thing Name: {0}\n", sample.SampleID), new Font(baseFont, 8f)));

                cell.AddElement(contents);
                table.AddCell(cell);

            }

            table.CompleteRow();
            doc.Add(table);

            // Close PDF document and send

            pdfWriter.CloseStream = false;
            doc.Close();
            memoryStream.Position = 0;

            return File(memoryStream, "application/pdf");
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
