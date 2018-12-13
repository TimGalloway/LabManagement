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
using LabManagementWeb.DAL;
using LabManagementWeb.Models;

namespace LabManagementWeb.Controllers
{
    [RoutePrefix("api/Samples")]
    public class SamplesAPIController : ApiController
    {
        private ISamplesRepository samplesRepository;
        private IAuditLogRepository auditLogRepository;

        public SamplesAPIController()
        {
            this.samplesRepository = new SamplesRespository(new ApplicationDbContext());
            this.auditLogRepository = new AuditLogRepository(new ApplicationDbContext());
        }

        [HttpPatch]
        public IHttpActionResult PatchSample([FromBody] SamplePatchRequest request)
        {
            Sample sample = samplesRepository.GetSampleByID(request.SampleID);
            if (sample == null)
            {
                return NotFound();
            }
            else
            {
                sample.Weight = request.Weight;
                samplesRepository.Save();

                AuditLog lAuditLog = new AuditLog();
                lAuditLog.AuditAction = "Sample Update from RPI - SampleID:"+ sample.SampleID + " Weight:" + sample.Weight;
                lAuditLog.AuditUser = "RPI";
                lAuditLog.AuditTime = DateTime.Now;
                auditLogRepository.InsertAuditLog(lAuditLog);
                auditLogRepository.Save();

                return Ok();
            }
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