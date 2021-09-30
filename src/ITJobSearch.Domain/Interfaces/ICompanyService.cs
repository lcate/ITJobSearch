using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface ICompanyService : IDisposable
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetById(int id);
        Task<Company> Add(Company company);
        Task<Company> Update(Company company);
        Task<bool> Remove(Company company);
        Task<IEnumerable<Company>> Search(string companyName);
        Task<Company> GetCompanyId(string id);
    }
}
