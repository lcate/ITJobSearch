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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ITJobSearchDbContext context) : base(context) { }

        public override async Task<List<Company>> GetAll()
        {
            return await Db.Companies.Include(b => b.JobOffers)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public override async Task<Company> GetById(int id)
        {
            return await Db.Companies.Include(b => b.JobOffers)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }


    }
}
