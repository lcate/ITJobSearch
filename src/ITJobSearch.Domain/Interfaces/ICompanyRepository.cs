using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        new Task<List<Company>> GetAll();

        new Task<Company> GetById(int id);

        Task<Company> GetCompanyId(string id);
    }
}
