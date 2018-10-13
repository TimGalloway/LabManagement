using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LabManagementWeb.Models
{
    public class Job : BaseModel
    {
        public int ID { get; set; }

        [DisplayName("Job Number")]
        public string JobNumber { get; set; }

        [DisplayName("Elements")]
        public string Elements { get; set; }

        [DisplayName("Standards")]
        public string Standards { get; set; }

        [DisplayName("Job Type")]
        public int JobType_ID { get; set; }

        public virtual JobType JobType { get; set; }
    }
}