using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb.Models
{
    public class Client : BaseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ClientAddress ClientAddress { get; set; }
    }
}