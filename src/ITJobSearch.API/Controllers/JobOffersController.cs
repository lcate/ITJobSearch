using AutoMapper;
using ITJobSearch.API.Controllers.Dtos;
using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
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
        private readonly IMapper _mapper;

        public JobOffersController(IMapper mapper,
                                    IJobOfferService jobOfferService)
        {
            _mapper = mapper;
            _jobOfferService = jobOfferService;
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
        public async Task<IActionResult> Update(int id, JobOfferEditDto jobOfferDto)
        {
            if (id != jobOfferDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _jobOfferService.Update(_mapper.Map<JobOffer>(jobOfferDto));

            return Ok(jobOfferDto);
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
    }
}
