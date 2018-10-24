using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabManagementWeb.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navbar
        public ActionResult TopNav()
        {
            var nav = new Navbar();
            return PartialView("_topNav", nav.NavbarTop());
        }
    }
}