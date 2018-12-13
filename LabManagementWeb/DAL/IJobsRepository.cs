using LabManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagementWeb.DAL
{
    public interface IJobsRepository : IDisposable
    {
        IEnumerable<Job> GetJobs();
        Job GetJobByID(int? jobID);
        void InsertJob(Job job);
        void DeleteJob(int jobID);
        void UpdateJob(Job job);
        void Save();
    }
}
