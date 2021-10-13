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

        public async Task<JobApplication> Add(JobApplication jobApplication)
        {
            if (_jobApplicationRepository.Search(c => c.Id == jobApplication.Id).Result.Any())
                return null;

            await _jobApplicationRepository.Add(jobApplication);
            return jobApplication;
        }

        public void Dispose()
        {
            _jobApplicationRepository?.Dispose();
        }

        public async Task<IEnumerable<JobApplication>> GetAll()
        {
            return await _jobApplicationRepository.GetAll();
        }

        public async Task<JobApplication> GetById(int id)
        {
            return await _jobApplicationRepository.GetById(id);
        }

        public async Task<List<JobApplication>> GetByUserId(string id)
        {
            return await _jobApplicationRepository.GetByUserId(id);
        }

        public async Task<List<JobApplication>> GetJobApplicationsByJobOfferId(int jobofferid)
        {
            return await _jobApplicationRepository.GetJobApplicationsByJobOfferId(jobofferid);
        }

        public async Task<bool> Remove(JobApplication jobApplication)
        {
            await _jobApplicationRepository.Remove(jobApplication);
            return true;
        }

        public async Task<JobApplication> Update(JobApplication jobApplication)
        {
            if (!_jobApplicationRepository.Search(c => c.Id == jobApplication.Id).Result.Any())
                return null;

            await _jobApplicationRepository.Update(jobApplication);
            return jobApplication;
        }
    }
}
