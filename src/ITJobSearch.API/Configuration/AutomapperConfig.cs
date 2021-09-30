using AutoMapper;
using ITJobSearch.API.Controllers.Dtos;
using ITJobSearch.API.Dtos;
using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<JobOffer, JobOfferAddDto>().ReverseMap();
            CreateMap<JobOffer, JobOfferEditDto>().ReverseMap();
            CreateMap<JobOffer, JobOfferResultDto>().ReverseMap();

            CreateMap<Company, CompanyAddDto>().ReverseMap();
            CreateMap<Company, CompanyEditDto>().ReverseMap();
            CreateMap<Company, CompanyResultDto>().ReverseMap();

            CreateMap<Comment, CommentAddDto>().ReverseMap();
            CreateMap<Comment, CommentEditDto>().ReverseMap();
            CreateMap<Comment, CommentResultDto>().ReverseMap();

            CreateMap<JobApplication, JobApplicationDto>().ReverseMap();
            CreateMap<JobApplication, JobApplicationAddDto>().ReverseMap();
        }
    }
}
