using LabManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LabManagementWeb.DAL
{
    public class JobsRepository :IJobsRepository, IDisposable
    {
        private ApplicationDbContext context;

        public JobsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Job> GetJobs()
        {
            return context.Jobs.ToList();
        }

        public Job GetJobByID(int? jobID)
        {
            return context.Jobs.Find(jobID);
        }

        public void InsertJob(Job job)
        {
            context.Jobs.Add(job);
        }

        public void DeleteJob(int jobID)
        {
            Job job = context.Jobs.Find(jobID);
            context.Jobs.Remove(job);
        }

        public void UpdateJob(Job job)
        {
            context.Entry(job).State = EntityState.Modified;
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