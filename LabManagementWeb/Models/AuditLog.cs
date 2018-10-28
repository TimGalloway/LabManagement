using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb.Models
{
    public class AuditLog : BaseModel
    {
        public int ID { get; set; }
        public DateTime AuditTime { get; set; }
        public string AuditUser { get; set; }
        public string AuditAction { get; set; }
    }
}