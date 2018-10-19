using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb.Models
{
    public class JobType : BaseModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Prefix { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}