using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface IJobApplicationRepository : IRepository<JobApplication>
    {
        new Task<List<JobApplication>> GetAll();

        new Task<JobApplication> GetById(int id);
    }
}
