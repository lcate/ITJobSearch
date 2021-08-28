using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Task<Comment> Add(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> Update(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
