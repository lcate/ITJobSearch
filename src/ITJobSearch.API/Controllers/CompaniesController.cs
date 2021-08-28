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
    [Route("/api/companies")]
    public class CompaniesController : MainController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(IMapper mapper,
                                    ICompanyService companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyService.GetAll();

            return Ok(_mapper.Map<IEnumerable<CompanyResultDto>>(companies));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyService.GetById(id);

            if (company == null) return NotFound();

            return Ok(_mapper.Map<CompanyResultDto>(company));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompanyAddDto companyDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var company = _mapper.Map<Company>(companyDto);
            var companyResult = await _companyService.Add(company);

            if (companyResult == null) return BadRequest();

            return Ok(_mapper.Map<CompanyResultDto>(companyResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CompanyEditDto companyDto)
        {
            if (id != companyDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _companyService.Update(_mapper.Map<Company>(companyDto));

            return Ok(companyDto);
        }
    }
}
