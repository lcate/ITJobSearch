using AutoMapper;
using ITJobSearch.API.Controllers.Dtos;
using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Controllers
{
    [Route("/api/[controller]")]
    public class CommentController : MainController
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly ICommentService _commentService;
        private readonly IJobOfferService _jobOfferService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public CommentController(IMapper mapper, 
                                 IJobApplicationService jobApplicationService,
                                 IJobOfferService jobOfferService,
                                 UserManager<AppUser> userManager,
                                 ICommentService commentService)
        {
            _commentService = commentService;
            _jobApplicationService = jobApplicationService;
            _userManager = userManager;
            _jobOfferService = jobOfferService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentService.GetAll();

            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentAddDto commentAddDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var templUser = await _userManager.FindByEmailAsync(commentAddDto.UserEmail);

            var comment = new Comment();
            comment.JobApplicationId = commentAddDto.JobApplicationId;
            comment.Message = commentAddDto.Message;
            comment.UserId = templUser.Id;
            comment.File = commentAddDto.File;
            comment.DateCreated = DateTime.Now;

            var commentResult = await _commentService.Add(comment);

            if (commentResult == null) return BadRequest();

            return Ok(_mapper.Map<Comment>(commentResult));
        }

        [HttpGet("byid/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentService.GetById(id);

            if (comment == null) return NotFound();

            return Ok(comment);
        }

        [HttpGet("jobapplication/{jobapplicationid:int}")]
        public async Task<IActionResult> GetCommentsByJobApplicationsId(int jobApplicationId)
        {
            List<Comment> comments = await _commentService.GetCommentsByJobApplicationsId(jobApplicationId);

            if (comments == null) return NotFound();

            foreach (Comment comment in comments)
            {
                comment.User = await _userManager.FindByIdAsync(comment.UserId);
            }

            return Ok(comments);
        }

    }
}
