using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LabManagementWeb.Models;

namespace LabManagementWeb.Controllers
{
    [RoutePrefix("api/Samples")]
    public class SamplesAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SamplesAPI
        public IQueryable<Sample> GetSamples()
        {
            return db.Samples;
        }

        // GET: api/SamplesAPI/5
        [ResponseType(typeof(Sample))]
        public IHttpActionResult GetSample(int id)
        {
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return NotFound();
            }

            return Ok(sample);
        }

        // PUT: api/SamplesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSample(int id, Sample sample)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sample.ID)
            {
                return BadRequest();
            }

            db.Entry(sample).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SamplesAPI
        [ResponseType(typeof(Sample))]
        public IHttpActionResult PostSample(Sample sample)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //sample.Job = db.Jobs.Find(sample.Job_ID);
            db.Samples.Add(sample);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sample.ID }, sample);
        }

        // DELETE: api/SamplesAPI/5
        [ResponseType(typeof(Sample))]
        public IHttpActionResult DeleteSample(int id)
        {
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return NotFound();
            }

            db.Samples.Remove(sample);
            db.SaveChanges();

            return Ok(sample);
        }

        [HttpPatch]
        public IHttpActionResult PatchSample([FromBody] SamplePatchRequest request)
        {
            Sample sample = (Sample)db.Samples.Where(a => a.SampleID == request.SampleID).FirstOrDefault<Sample>();
            if (sample == null)
            {
                return NotFound();
            }
            else
            {
                sample.Weight = request.Weight;
                db.SaveChanges();

                //AuditLog lAuditLog = new AuditLog();
                //lAuditLog.AuditAction = "Sample Update from RPI";
                //lAuditLog.AuditUser = "RPI";
                //lAuditLog.AuditTime = DateTime.Now;
                //db.AuditLogs.Add(lAuditLog);
                //db.SaveChanges();

                return Ok();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SampleExists(int id)
        {
            return db.Samples.Count(e => e.ID == id) > 0;
        }
    }
}