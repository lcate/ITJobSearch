using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        new Task<List<Comment>> GetAll();

        new Task<Comment> GetById(int id);
    }
}
