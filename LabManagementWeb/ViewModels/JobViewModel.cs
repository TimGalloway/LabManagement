using LabManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabManagementWeb.ViewModels
{
    public class JobViewModel
    {
        public Job Job { get; set; }
        public JobTypeViewModel JobTypes { get; set; }
    }
}