using LabManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabManagementWeb.DAL
{
    public interface IJobTypesRepository : IDisposable
    {
        IEnumerable<JobType> GetJobTypes();
        JobType GetJobTypeByID(int? jobTypeID);
        void InsertJobType(JobType jobtype);
        void DeleteJobType(int jobTypeID);
        void UpdateJobType(JobType jobtype);
        void Save();
    }
}