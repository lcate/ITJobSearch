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
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ITJobSearchDbContext context) : base(context) { }

        public async Task<IEnumerable<Comment>> GetCommentsByJobApplication(int jobApplicationId)
        {
            return await Search(b => b.JobApplicationId == jobApplicationId);
        }

    }
}
