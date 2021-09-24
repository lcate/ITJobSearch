using AutoMapper;
using ITJobSearch.API.Controllers.Dtos;
using ITJobSearch.API.Enums;
using ITJobSearch.API.Model;
using ITJobSearch.API.Model.BindingModel;
using ITJobSearch.API.Model.DTO;
using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
using ITJobSearch.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly JWTConfig _jWTConfig;

        private readonly IMapper _mapper;

        private ICompanyRepository _companiesController;

        public UserController(ILogger<UserController> logger,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, 
            IOptions<JWTConfig> jwtConfig, 
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            ICompanyRepository companiesController)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _jWTConfig = jwtConfig.Value;
            _roleManager = roleManager;
            _mapper = mapper;
            _companiesController = companiesController;
        }


        [HttpPost("registeruser")]
        public async Task<object> RegisterUser([FromBody] AddUpdateRegisterUserBindingModel model)
        {
            try
            {
                if (!await _roleManager.RoleExistsAsync(model.Role))
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Role does not exist", null));
                }

                var user = new AppUser() { FullName = model.FullName, Email = model.Email, UserName = model.Email, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var tempUser = await _userManager.FindByEmailAsync(model.Email);
                    await _userManager.AddToRoleAsync(tempUser, model.Role);
                    var companyToAdd = new Company();
                    if (model.Role == "Company")
                    {
                        companyToAdd = new Company() { Name = model.FullName, WebURL = model.WebURL, Logo = model.Logo, UserId = tempUser.Id };
                        companyToAdd.Linkedin = model.Linkedin;
                        companyToAdd.AboutUs = model.AboutUs;
                        await _companiesController.Add(companyToAdd);
                    }
                    var userResult = new UserDTO(model.FullName, model.Email, model.Email, DateTime.UtcNow, model.Role);
                    userResult.CompanyId = companyToAdd.Id;
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "User has been registered.", userResult));
                }

                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "", result.Errors.Select(x => x.Description).ToArray()));

            } catch(Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
            
        }


        [HttpGet("getalluser")]
        public async Task<object> GetAllUser()
        {
            try
            {
                List<UserDTO> allUserDTO = new List<UserDTO>();
                var users = _userManager.Users.ToList();
                foreach(var user in users)
                {
                    var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

                    allUserDTO.Add(new UserDTO(user.FullName, user.Email, user.UserName, user.DateCreated, role));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", allUserDTO));
            } catch(Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }

        [HttpGet("getuser/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<object> Login([FromBody] LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        AppUser appUser = await _userManager.FindByEmailAsync(model.Email);
                        string role = (await _userManager.GetRolesAsync(appUser)).FirstOrDefault();
                        UserDTO user = new UserDTO(appUser.FullName, appUser.Email, appUser.UserName, appUser.DateCreated, role);
                        user.Token = GenerateToken(appUser, role);
                        if (role == "Company")
                        {
                            var company = await _companiesController.GetCompanyId(appUser.Id);
                            user.CompanyId = company.Id;
                        }
                        return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", user));
                    }
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Invalid Email or Password", null));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }

        [HttpPost("addrole")]
        public async Task<object> AddRole([FromBody] AddRoleBindingModel model)
        {
            try
            {
                if (model == null || model.Role == "")
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Parametars are missing", null));
                }

                if (await _roleManager.RoleExistsAsync(model.Role)) {
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Role already exists", null));
                }

                var role = new IdentityRole();
                role.Name = model.Role;
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Role added successfully", null));
                }

                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Something went wrong, please try again later", null));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }

        [HttpGet("getroles")]
        public async Task<object> GetRoles()
        {
            try
            {
                var roles = _roleManager.Roles.Select(c => c.Name).ToList();
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", roles));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
        }

        private string GenerateToken(AppUser user, string role)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jWTConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] {
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new System.Security.Claims.Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jWTConfig.Audience,
                Issuer = _jWTConfig.Issuer
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

    }
}
