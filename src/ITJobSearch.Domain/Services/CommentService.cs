﻿using ITJobSearch.Domain.Interfaces;
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

        public async Task<Comment> Add(Comment comment)
        {
            if (_commentRepository.Search(c => c.Id == comment.Id).Result.Any())
                return null;

            await _commentRepository.Add(comment);
            return comment;
        }

        public void Dispose()
        {
            _commentRepository?.Dispose();
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _commentRepository.GetAll();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _commentRepository.GetById(id);
        }

        public async Task<List<Comment>> GetCommentsByJobApplicationsId(int jobApplicationId)
        {
            return await _commentRepository.GetCommentsByJobApplicationsId(jobApplicationId);
        }

        public async Task<bool> Remove(Comment comment)
        {
            await _commentRepository.Remove(comment);
            return true;
        }

        public async Task<Comment> Update(Comment comment)
        {
            if (!_commentRepository.Search(c => c.Id == comment.Id).Result.Any())
                return null;

            await _commentRepository.Update(comment);
            return comment;
        }
    }
}
