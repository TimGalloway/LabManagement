using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb.Models
{
    public class ClientAddress : BaseModel
    {
        public int ClientAddressID { get; set; }
        public string ClientAddressName { get; set; }
        public string ClientAddressContact { get; set; }
        public string ClientAddressLine1 { get; set; }
        public string ClientAddressLine2 { get; set; }
        public string ClientAddressEmail { get; set; }
        public string ClientAddressPhone { get; set; }
        public string ClientAddressFax { get; set; }

        public virtual ClientAddressType ClientAddressType { get; set; }

        public virtual ICollection<Client> Client { get; set; }
    }
}