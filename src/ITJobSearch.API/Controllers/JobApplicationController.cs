using AutoMapper;
using ITJobSearch.API.Controllers.Dtos;
using ITJobSearch.API.Dtos;
using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Controllers
{
    [Route("/api/jobapplications")]
    public class JobApplicationController : MainController
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public JobApplicationController(IMapper mapper,
                                    IJobApplicationService jobApplicationService,
                                    UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _jobApplicationService = jobApplicationService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobApplications = await _jobApplicationService.GetAll();

            return Ok(jobApplications);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jobApplication = await _jobApplicationService.GetById(id);

            if (jobApplication == null) return NotFound();

            return Ok(jobApplication);
        }

        [HttpPost]
        public async Task<IActionResult> Add(JobApplicationDto jobApplicationDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var tempUser = await _userManager.FindByEmailAsync(jobApplicationDto.UserEmail);

            var jobApplication1 = new JobApplicationAddDto();
            jobApplication1.JobOfferId = jobApplicationDto.JobOfferId;
            jobApplication1.UserId = tempUser.Id;
            jobApplication1.ImgPath = jobApplicationDto.ImgPath;

            var jobApplication = _mapper.Map<JobApplication>(jobApplication1);
            var jobApplicationResult = await _jobApplicationService.Add(jobApplication);

            if (jobApplicationResult == null) return BadRequest();

            return Ok(_mapper.Map<JobApplication>(jobApplicationResult));
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetJobApplicationsForUser(string email)
        {
            var tempUser = await _userManager.FindByEmailAsync(email);

            if (tempUser == null) return NotFound();

            var applications = await _jobApplicationService.GetByUserId(tempUser.Id);

            return Ok(applications);
        }

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Update(int id, CompanyEditDto companyDto)
        //{
        //    if (id != companyDto.Id) return BadRequest();

        //    if (!ModelState.IsValid) return BadRequest();

        //    await _companyService.Update(_mapper.Map<Company>(companyDto));

        //    return Ok(companyDto);
        //}
    }
}
