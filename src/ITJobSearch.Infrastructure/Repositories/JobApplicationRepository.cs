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
    public class JobApplicationRepository : Repository<JobApplication>, IJobApplicationRepository
    {
        public JobApplicationRepository(ITJobSearchDbContext context) : base(context) { }

        public override async Task<List<JobApplication>> GetAll()
        {
            var jobApplications = await Db.JobApplications.Include(b => b.JobOffer)
                .OrderBy(c => c.Id)
                .ToListAsync();
            return jobApplications;
        }

        public override async Task<JobApplication> GetById(int id)
        {
            var k = await Db.JobApplications.Include(b => b.JobOffer)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            return k;
        }

        public async Task<List<JobApplication>> GetByUserId(string id)
        {
            var k = await Db.JobApplications
                .Where(b => b.UserId == id)
                .ToListAsync();
            return k;
        }
    }
}
