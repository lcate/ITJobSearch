using AutoMapper;
using ITJobSearch.API.Controllers.Dtos;
using ITJobSearch.API.Model.DTO;
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
    [Route("/api/companies")]
    public class CompaniesController : MainController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public CompaniesController(IMapper mapper,
                                    UserManager<AppUser> userManager,
                                    ICompanyService companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
            _userManager = userManager;
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

            AppUser user = await _userManager.FindByIdAsync(company.UserId);

            company.User = user;

            return Ok(company);
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

            Company company = await _companyService.GetById(id);

            AppUser user = await _userManager.FindByIdAsync(company.UserId);

            company.Name = companyDto.Name;
            company.WebURL = companyDto.URL;
            company.EmployeesFrom = companyDto.EmployeesFrom;
            company.EmployeesTo = companyDto.EmployeesTo;
            company.YearFounded = companyDto.YearFounded;
            company.Locations = companyDto.Locations;

            await _companyService.Update(company);

            user.ProfilePicture = companyDto.ProfilePicture;
            user.FullName = companyDto.Name;
            user.Linkedin = companyDto.Linkedin;
            user.AboutMe = companyDto.AboutUs;
            user.Address = companyDto.Address;
            user.PhoneNumber = companyDto.PhoneNumber;
            user.City = companyDto.City;

            await _userManager.UpdateAsync(user);
            company.User = user;

            UserDTO userDto = new UserDTO(user.FullName, user.Email, user.UserName, user.DateCreated, user.ProfilePicture, "Company");
            userDto.CompanyId = company.Id;

            return Ok(userDto);
        }
    }
}
