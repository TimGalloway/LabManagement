using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabManagementWeb.ViewModels
{
    public class JobTypeViewModel
    {
        public int SelectedID { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}