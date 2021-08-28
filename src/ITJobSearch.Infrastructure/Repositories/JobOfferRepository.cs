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

    }
}
