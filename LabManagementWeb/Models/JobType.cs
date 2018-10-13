using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LabManagementWeb.Models
{
    public class JobType : BaseModel
    {
        public int ID { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Prefix")]
        public string Prefix { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}