using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface IJobOfferService : IDisposable
    {
        Task<IEnumerable<JobOffer>> GetAll();
        Task<JobOffer> GetById(int id);
        Task<JobOffer> Add(JobOffer jobOffer);
        Task<JobOffer> Update(JobOffer jobOffer);
        Task<bool> Remove(JobOffer jobOffer);
        Task<List<JobOffer>> GetJobOffersByCompanyId(int companyid);
    }
}
