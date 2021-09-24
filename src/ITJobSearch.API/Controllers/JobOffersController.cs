using AutoMapper;
using ITJobSearch.API.Controllers.Dtos;
using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Controllers
{
    [Route("/api/joboffers")]
    public class JobOffersController : MainController
    {
        private readonly IJobOfferService _jobOfferService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public JobOffersController(IMapper mapper,
                                    IJobOfferService jobOfferService,
                                    ICompanyService companyService)
        {
            _mapper = mapper;
            _jobOfferService = jobOfferService;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobOffers = await _jobOfferService.GetAll();

            return Ok(_mapper.Map<IEnumerable<JobOfferResultDto>>(jobOffers));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jobOffer = await _jobOfferService.GetById(id);

            if (jobOffer == null) return NotFound();

            return Ok(_mapper.Map<JobOfferResultDto>(jobOffer));
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
    }
}
