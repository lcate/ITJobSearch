using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface ICommentService : IDisposable
    {
        Task<IEnumerable<Comment>> GetAll();
        Task<Comment> GetById(int id);
        Task<Comment> Add(Comment comment);
        Task<Comment> Update(Comment comment);
        Task<bool> Remove(Comment comment);
    }
}
