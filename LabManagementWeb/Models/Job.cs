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
        public string Elements { get; set; }
        public string Standards { get; set; }
        public int JobType_ID { get; set; }

        public virtual JobType JobType { get; set; }
    }
}