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
            List<JobApplication> jobApplications = await Db.JobApplications
                                                        .Include(b => b.JobOffer)
                                                        .OrderBy(c => c.Id)
                                                        .ToListAsync();
            return jobApplications;
        }

        public override async Task<JobApplication> GetById(int id)
        {
            JobApplication jobApplication = await Db.JobApplications
                                            .Include(b => b.JobOffer).ThenInclude(j => j.Company)
                                            .Where(b => b.Id == id)
                                            .FirstOrDefaultAsync();
            return jobApplication;
        }

        public async Task<List<JobApplication>> GetByUserId(string id)
        {
            List<JobApplication> jobApplications = await Db.JobApplications.Include(jo => jo.JobOffer).ThenInclude(j => j.Company)
                                                            .Where(b => b.UserId == id)
                                                            .ToListAsync();
            return jobApplications;
        }

        public async Task<List<JobApplication>> GetJobApplicationsByJobOfferId(int jobofferid)
        {
            List<JobApplication> jobApplications = await Db.JobApplications.Include(ja => ja.JobOffer)
                                                    .ThenInclude(jo => jo.Company)
                                                    .Where(ja => ja.JobOfferId == jobofferid)
                                                    .ToListAsync();
            return jobApplications;
        }

    }
}
