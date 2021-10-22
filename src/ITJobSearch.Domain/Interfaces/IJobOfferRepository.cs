using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface IJobOfferRepository : IRepository<JobOffer>
    {
        new Task<List<JobOffer>> GetAll();

        new Task<JobOffer> GetById(int id);

        Task<List<JobOffer>> GetJobOffersByCompanyId(int companyid);
    }
}
