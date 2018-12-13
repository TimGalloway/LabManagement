using LabManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagementWeb.DAL
{
    interface IAuditLogRepository : IDisposable
    {
        void InsertAuditLog(AuditLog auditLog);
        void Save();
    }
}
