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
        public override async Task<List<Comment>> GetAll()
        {
            return await Db.Comments.Include(b => b.JobApplication)
                .OrderBy(c => c.Id)
                .ToListAsync();
        }

        public override async Task<Comment> GetById(int id)
        {
            return await Db.Comments
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Comment>> GetCommentsByJobApplicationsId(int jobApplicationId)
        {
            return await Db.Comments.Include(c => c.JobApplication)
                            .Where(c => c.JobApplicationId == jobApplicationId)
                            .ToListAsync();
        }
    }
}
