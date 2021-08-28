using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public JobApplicationService(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public Task<JobApplication> Add(JobApplication jobApplication)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<JobApplication>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<JobApplication> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(JobApplication jobApplication)
        {
            throw new NotImplementedException();
        }

        public Task<JobApplication> Update(JobApplication jobApplication)
        {
            throw new NotImplementedException();
        }
    }
}
