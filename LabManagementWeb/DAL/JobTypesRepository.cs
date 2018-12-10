using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LabManagementWeb.Models;

namespace LabManagementWeb.DAL
{
    public class JobTypesRepository : IJobTypesRepository, IDisposable
    {
        private ApplicationDbContext context;

        public JobTypesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<JobType> GetJobTypes()
        {
            return context.JobTypes.ToList();
        }

        public JobType GetJobTypeByID(int? jobTypeID)
        {
            return context.JobTypes.Find(jobTypeID);
        }

        public void InsertJobType(JobType jobtype)
        {
            context.JobTypes.Add(jobtype);
        }

        public void DeleteJobType(int jobTypeID)
        {
            JobType jobType = context.JobTypes.Find(jobTypeID);
            context.JobTypes.Remove(jobType);
        }

        public void UpdateJobType(JobType jobtype)
        {
            context.Entry(jobtype).State = EntityState.Modified;
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