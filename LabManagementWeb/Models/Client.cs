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
        public string Company { get; set; }
        public string MailingAddress { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public bool SendInvToSame { get; set; }
        public string InvoiceName { get; set; }
        public string InvoiceCompany { get; set; }
        public string InvoiceMailingAddress { get; set; }
        public string InvoiceEmailAddress { get; set; }
        public string InvoicePhoneNumber { get; set; }
        public string InvoiceFaxNumber { get; set; }
    }
}