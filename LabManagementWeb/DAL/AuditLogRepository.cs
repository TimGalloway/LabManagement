using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LabManagementWeb.Models;

namespace LabManagementWeb.DAL
{
    public class AuditLogRepository : IAuditLogRepository, IDisposable
    {
        private ApplicationDbContext context;

        public AuditLogRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void InsertAuditLog(AuditLog auditLog)
        {
            context.AuditLogs.Add(auditLog);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}