﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb.ViewModels
{
    public class CustomPrincipal
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] roles { get; set; }
    }
}