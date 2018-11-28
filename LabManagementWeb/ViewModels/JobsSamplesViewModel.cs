using LabManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb.ViewModels
{
    public class JobsSamplesViewModel
    {
        public Job job { get; set; }
        public List<Sample> samples { get; set; }
    }
}