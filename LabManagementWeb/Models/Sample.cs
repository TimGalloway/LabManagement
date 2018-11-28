using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb.Models
{
    public class Sample : BaseModel
    {
        public int ID { get; set; }
        public int SampleID { get; set; }
        public decimal Weight { get; set; }

        public int Job_ID { get; set; }

        public virtual Job Job { get; set; }
    }
}