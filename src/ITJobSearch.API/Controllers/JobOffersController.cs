using AutoMapper;
using ITJobSearch.API.Controllers.Dtos;
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
    public class JobOffersController : MainController
    {
        private readonly IJobOfferService _jobOfferService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public JobOffersController(IMapper mapper,
                                    IJobOfferService jobOfferService,
                                    UserManager<AppUser> userManager,
                                    ICompanyService companyService)
        {
            _mapper = mapper;
            _jobOfferService = jobOfferService;
            _companyService = companyService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobOffers = await _jobOfferService.GetAll();

            foreach (JobOffer jobOffer in jobOffers)
            {
                var user = await _userManager.FindByIdAsync(jobOffer.Company.UserId);
                jobOffer.Company.User = user;
            }

            return Ok(jobOffers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jobOffer = await _jobOfferService.GetById(id);

            if (jobOffer == null) return NotFound();

            jobOffer.Company.User = await _userManager.FindByIdAsync(jobOffer.Company.UserId);

            return Ok(jobOffer);
        }

        [HttpPost]
        public async Task<IActionResult> Add(JobOfferAddDto jobOfferDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var jobOffer = _mapper.Map<JobOffer>(jobOfferDto);
            var jobOfferResult = await _jobOfferService.Add(jobOffer);

            if (jobOfferResult == null) return BadRequest();

            return Ok(_mapper.Map<JobOfferResultDto>(jobOfferResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, JobOfferEditDto jobOfferDto)
        {
            if (id != jobOfferDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var jo = await _jobOfferService.GetById(id);
            jo.CompanyId = jobOfferDto.CompanyId;
            jo.Description = jobOfferDto.Description;
            jo.Position = jobOfferDto.Position;
            jo.Salary = jobOfferDto.Salary;
            jo.WorkHours = jobOfferDto.WorkHours;
            jo.WorkType = jobOfferDto.WorkType;
            jo.Experience = jobOfferDto.Experience;

            //var jobOffer = _mapper.Map<JobOffer>(jobOfferDto);
            var jobOfferResult = await _jobOfferService.Update(jo);

            if (jobOfferResult == null) return BadRequest();

            return Ok(_mapper.Map<JobOfferResultDto>(jobOfferResult));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var jobOffer = await _jobOfferService.GetById(id);
            if (jobOffer == null) return NotFound();

            var result = await _jobOfferService.Remove(jobOffer);

            if (!result) return BadRequest();

            return Ok();
        }

        [HttpGet("exists/{id:int}")]
        public async Task<IActionResult> JobOfferExists(int id)
        {
            var jobOffer = await _jobOfferService.GetById(id);

            if (jobOffer == null) return Ok(false);

            return Ok(true);
        }

        [HttpGet("company/{companyid}")]
        public async Task<IActionResult> GetJobOffersForCompany(int companyid)
        {
            var jobOffers = await _jobOfferService.GetJobOffersByCompanyId(companyid);

            if (jobOffers == null) return NotFound();

            foreach(JobOffer jobOffer in jobOffers)
            {
                var user = await _userManager.FindByIdAsync(jobOffer.Company.UserId);
                jobOffer.Company.User = user;
            }

            return Ok(jobOffers);
        }
    }
}
