using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb.Models
{
    public class Job : BaseModel
    {
        public int ID { get; set; }
        public string JobNumber { get; set; }
        public string SubmissionReference { get; set; }
        public string BulkaBagNumber { get; set; }
        public string ClientOrder { get; set; }

        public bool SendReportQLAB { get; set; }
        public bool SendReportEmail { get; set; }
        public bool SendReportOther { get; set; }
        public string SendReportOtherDetails { get; set; }

        public bool Dispose { get; set; }
        public bool Stored { get; set; }
        public DateTime StoredUntil { get; set; }
        public bool ReturnedToClient { get; set; }
        public string ReturnByCourier { get; set; }
        public string ReturnByCourierAccnt { get; set; }

        public bool SampleTypeRABRC { get; set; }
        public bool SampleTypeMETPLANT { get; set; }
        public bool SampleTypeUMPIREPARTY { get; set; }
        public bool SampleTypePULPS { get; set; }
        public bool SampleTypeSOILS { get; set; }
        public bool SampleTypeCOREROCKS { get; set; }
        public bool SampleTypeSOLUTIONS { get; set; }
        public bool SampleTypesMMI { get; set; }
        public bool SampleTypeOTHER { get; set; }
        public string SampleTypeOTHERDetails { get; set; }

        public int SampleIDStart { get; set; }
        public int SampleIDEnd { get; set; }

        public int JobType_ID { get; set; }

        public virtual JobType JobType { get; set; }
    }
}