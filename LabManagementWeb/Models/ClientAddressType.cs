using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb.Models
{
    public class ClientAddressType : BaseModel
    {
        public int ClientAddressTypeID { get; set; }
        public string ClientAddressTypeDescription { get; set; }

        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
    }
}