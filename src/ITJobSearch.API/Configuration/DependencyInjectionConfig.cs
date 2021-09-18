using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
using ITJobSearch.Domain.Services;
using ITJobSearch.Infrastructure.Context;
using ITJobSearch.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ITJobSearch.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITJobSearchDbContext>();

            services.AddScoped<IJobOfferRepository, JobOfferRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
            services.AddScoped<IUserTestRepository, UserTestRepository>();
            services.AddScoped<ITestRepository, TestRepository>();

            services.AddScoped<IJobOfferService, JobOfferService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IJobApplicationService, JobApplicationService>();
            services.AddScoped<IUserTestService, UserTestService>();
            services.AddScoped<ITestService, TestService>();

            return services;
        }
    }
}
