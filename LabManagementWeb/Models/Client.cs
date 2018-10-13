using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LabManagementWeb.Models
{
    public class Client : BaseModel
    {
        public int ID { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Postal Address")]
        public string PostalAddress { get; set; }

        [DisplayName("Contact Name")]
        public string ContactName { get; set; }
    }
}