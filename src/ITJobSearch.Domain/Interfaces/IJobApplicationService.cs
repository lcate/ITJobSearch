using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface IJobApplicationService : IDisposable
    {
        Task<IEnumerable<JobApplication>> GetAll();
        Task<JobApplication> GetById(int id);
        Task<JobApplication> Add(JobApplication jobApplication);
        Task<JobApplication> Update(JobApplication jobApplication);
        Task<bool> Remove(JobApplication jobApplication);
        Task<List<JobApplication>> GetByUserId(string id);
    }
}
