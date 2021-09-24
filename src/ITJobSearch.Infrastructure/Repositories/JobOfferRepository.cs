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
            var jobOffers = await Db.JobOffers.Include(b => b.Company)
                .OrderBy(c => c.Id)
                .ToListAsync();
            return jobOffers;
        }

        public override async Task<JobOffer> GetById(int id)
        {
            var k = await Db.JobOffers.Include(b => b.Company)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            return k;
        }

    }
}
