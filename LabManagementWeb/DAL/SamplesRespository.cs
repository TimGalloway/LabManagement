using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LabManagementWeb.Models;

namespace LabManagementWeb.DAL
{
    public class SamplesRespository : ISamplesRepository, IDisposable
    {
        private ApplicationDbContext context;

        public SamplesRespository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Sample> GetSamples()
        {
            return context.Samples.ToList();
        }

        public Sample GetSampleByID(int? sampleID)
        {
            return context.Samples.Find(sampleID);
        }

        public IEnumerable<Sample> GetSamplesforJob(int? jobID)
        {
            return context.Samples.Where(a => a.Job_ID == jobID).ToList();
        }

        public void InsertSample(Sample sample)
        {
            context.Samples.Add(sample);
        }

        public void DeleteSample(int sampleID)
        {
            Sample sample = context.Samples.Find(sampleID);
            context.Samples.Remove(sample);
        }

        public void UpdateSample(Sample sample)
        {
            context.Entry(sample).State = EntityState.Modified;
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