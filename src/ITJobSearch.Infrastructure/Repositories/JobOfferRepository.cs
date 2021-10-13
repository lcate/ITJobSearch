using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
using ITJobSearch.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Infrastructure.Repositories
{
    public class JobOfferRepository : Repository<JobOffer>, IJobOfferRepository
    {
        public JobOfferRepository(ITJobSearchDbContext context) : base(context) { }

        public override async Task<List<JobOffer>> GetAll()
        {
            List<JobOffer> jobOffers = await Db.JobOffers.Include(b => b.Company)
                .OrderBy(c => c.Id)
                .ToListAsync();
            return jobOffers;
        }

        public override async Task<JobOffer> GetById(int id)
        {
            JobOffer jobOffer = await Db.JobOffers.Include(b => b.Company)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            return jobOffer;
        }

        public async Task<List<JobOffer>> GetJobOffersByCompanyId(int companyid)
        {
            List<JobOffer> jobOffers = await Db.JobOffers
                .Where(b => b.CompanyId == companyid)
                .ToListAsync();
            return jobOffers;
        }
    }
}
