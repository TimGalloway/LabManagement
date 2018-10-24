using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb
{
    public class NavbarItem
    {
        public int Id { get; set; }
        public string nameOption { get; set; }
        public string controller { get; set; }
        public string action { get; set; }
        public bool havingImageClass { get; set; }
        public string cssClass { get; set; }
        public int parentId { get; set; }
        public bool isParent { get; set; }
    }
    public class Navbar
    {
        public IEnumerable<NavbarItem> NavbarTop()
        {
            var topNav = new List<NavbarItem>();
            topNav.Add(new NavbarItem() { Id = 1, action = "About", nameOption = "About", controller = "Home", isParent = false, parentId = -1 });
            topNav.Add(new NavbarItem() { Id = 2, action = "Contact", nameOption = "Contact", controller = "Home", isParent = false, parentId = -1 });
            //// drop down Menu 
            //topNav.Add(new NavbarItem() { Id = 3, action = "Reports", nameOption = "Reports", controller = "ReportGen", isParent = true, parentId = -1 });
            //topNav.Add(new NavbarItem() { Id = 4, action = "SummaryReport", nameOption = "Overall Summary", controller = "ReportGen", isParent = false, parentId = 3 });
            //topNav.Add(new NavbarItem() { Id = 5, action = "DailyReport", nameOption = "Today Report", controller = "ReportGen", isParent = false, parentId = 3 });
            //topNav.Add(new NavbarItem() { Id = 6, action = "MonthlyReport", nameOption = "Month Report", controller = "ReportGen", isParent = false, parentId = 3 });
            // End drop down Menu
            //topNav.Add(new NavbarItem() { Id = 7, action = "Action", nameOption = "Other action", controller = "Home", isParent = false, parentId = -1 });
            return topNav;
        }
    }
}