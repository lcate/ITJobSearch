using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Services
{
    public class JobOfferService : IJobOfferService
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public JobOfferService(IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task<JobOffer> Add(JobOffer jobOffer)
        {
            if (_jobOfferRepository.Search(c => c.Id == jobOffer.Id).Result.Any())
                return null;

            await _jobOfferRepository.Add(jobOffer);
            return jobOffer;
        }

        public void Dispose()
        {
            _jobOfferRepository?.Dispose();
        }

        public async Task<IEnumerable<JobOffer>> GetAll()
        {
            return await _jobOfferRepository.GetAll();
        }

        public async Task<JobOffer> GetById(int id)
        {
            return await _jobOfferRepository.GetById(id);
        }

        public async Task<bool> Remove(JobOffer jobOffer)
        {
            await _jobOfferRepository.Remove(jobOffer);
            return true;
        }

        public async Task<JobOffer> Update(JobOffer jobOffer)
        {
            if (!_jobOfferRepository.Search(c => c.Id == jobOffer.Id).Result.Any())
                return null;

            await _jobOfferRepository.Update(jobOffer);
            return jobOffer;
        }
    }
}
