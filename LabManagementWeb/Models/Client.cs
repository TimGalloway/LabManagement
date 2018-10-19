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
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalAddress { get; set; }
        public string ContactName { get; set; }
    }
}