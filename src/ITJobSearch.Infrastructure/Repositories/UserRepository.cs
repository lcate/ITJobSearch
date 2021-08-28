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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ITJobSearchDbContext context) : base(context) { }

    }
}
