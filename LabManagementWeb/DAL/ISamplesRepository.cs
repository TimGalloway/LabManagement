using LabManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagementWeb.DAL
{
    public interface ISamplesRepository : IDisposable
    {
        IEnumerable<Sample> GetSamples();
        Sample GetSampleByID(int? sampleID);
        IEnumerable<Sample> GetSamplesforJob(int? jobID);
        void InsertSample(Sample sample);
        void DeleteSample(int sampleID);
        void UpdateSample(Sample sample);
        void Save();
    }
}
