﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabManagementWeb.Models
{
    public class Client : BaseModel
    {
        public int ID { get; set; }

        [Display(Name ="Name")]
        public string Name { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }
        public string MailingAddress { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }

        [Display(Name = "Send To Same")]
        public bool SendInvToSame { get; set; }
        public string InvoiceName { get; set; }
        public string InvoiceCompany { get; set; }
        public string InvoiceMailingAddress { get; set; }
        public string InvoiceEmailAddress { get; set; }
        public string InvoicePhoneNumber { get; set; }
        public string InvoiceFaxNumber { get; set; }
    }
}