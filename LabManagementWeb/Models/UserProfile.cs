using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb.Models
{
    public class UserProfile : BaseModel
    {
        public int ID { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public Boolean IsActive { get; set; }
    }
}