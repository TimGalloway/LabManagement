using LabManagementWeb.Helpers;
using LabManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Zen.Barcode;

namespace LabManagementWeb.DAL
{
    public class JobsRepository :IJobsRepository, IDisposable
    {
        private ApplicationDbContext context;
        private ISamplesRepository samplesRepository;
        private IJobTypesRepository jobTypesRepository;


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
            this.samplesRepository = new SamplesRespository(context);

            context.Jobs.Add(job);

            //Create samples records using SampleIDStart and SampleIDEnd
            for (int sampleLoop = job.SampleIDStart; sampleLoop <= job.SampleIDEnd; sampleLoop++)
            {
                Code39BarcodeDraw barcode39 = BarcodeDrawFactory.Code39WithoutChecksum;
                System.Drawing.Image img = barcode39.Draw(sampleLoop.ToString(), 40);

                Sample newSample = new Sample
                {
                    Job = job,
                    Job_ID = job.ID,
                    SampleID = sampleLoop,
                    BarCodeImage = Convert.ToBase64String(Functions.imageToByteArray(img))

                };
                samplesRepository.InsertSample(newSample);
            }
            samplesRepository.Save();
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