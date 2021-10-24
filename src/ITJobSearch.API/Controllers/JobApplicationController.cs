using AutoMapper;
using ITJobSearch.API.Controllers.Dtos;
using ITJobSearch.API.Dtos;
using ITJobSearch.API.Dtos.JobApplications;
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
    [Route("/api/[controller]")]
    public class JobApplicationController : MainController
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IJobOfferService _jobOfferService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public JobApplicationController(IMapper mapper,
                                    IJobApplicationService jobApplicationService,
                                    IJobOfferService jobOfferService,
                                    UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _jobApplicationService = jobApplicationService;
            _userManager = userManager;
            _jobOfferService = jobOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobApplications = await _jobApplicationService.GetAll();

            return Ok(jobApplications);
        }

        [HttpGet("byid/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jobApplication = await _jobApplicationService.GetById(id);

            if (jobApplication == null) return NotFound();

            jobApplication.JobOffer.Company.User = await _userManager.FindByIdAsync(jobApplication.JobOffer.Company.UserId);
            jobApplication.User = await _userManager.FindByIdAsync(jobApplication.UserId);

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
            AppUser tempUser = await _userManager.FindByEmailAsync(email);

            if (tempUser == null) return NotFound();

            List<JobApplication> jobApplications = await _jobApplicationService.GetByUserId(tempUser.Id);

            foreach(JobApplication jobApplication in jobApplications)
            {
                jobApplication.JobOffer.Company.User = await _userManager.FindByIdAsync(jobApplication.JobOffer.Company.UserId);
            }

            //foreach (JobApplication jobApplication in jobApplications)
            //{
            //    jobApplication.User = tempUser;
            //}

            return Ok(jobApplications);
        }

        [HttpGet("joboffer/{jobofferid:int}")]
        public async Task<IActionResult> GetJobApplicationsByJobOfferId(int jobOfferId)
        {
            List<JobApplication> jobApplications = await _jobApplicationService.GetJobApplicationsByJobOfferId(jobOfferId);

            if (jobApplications == null) return NotFound();

            foreach (JobApplication jobApplication in jobApplications)
            {
                jobApplication.User = await _userManager.FindByIdAsync(jobApplication.UserId);
            }

            return Ok(jobApplications);
        }

        [HttpPut("updatestatus")]
        public async Task<IActionResult> UpdateStatusForJobApplication(UpdateStatusDto updateStatusDto)
        {
            JobApplication jobApplication = await _jobApplicationService.GetById(updateStatusDto.JobApplicationId);
            jobApplication.Status = updateStatusDto.NewStatus;

            await _jobApplicationService.Update(jobApplication);
            
            return Ok(jobApplication);
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
