using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> Add(Company company)
        {
            if (_companyRepository.Search(c => c.Name == company.Name).Result.Any())
                return null;

            await _companyRepository.Add(company);
            return company;
        }

        public void Dispose()
        {
            _companyRepository?.Dispose();
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _companyRepository.GetAll();
        }

        public async Task<Company> GetById(int id)
        {
            return await _companyRepository.GetById(id);
        }

        public async Task<bool> Remove(Company company)
        {
            await _companyRepository.Remove(company);
            return true;
        }

        public async Task<IEnumerable<Company>> Search(string companyName)
        {
            return await _companyRepository.Search(c => c.Name.Contains(companyName));
        }

        public async Task<Company> Update(Company company)
        {
            if (_companyRepository.Search(c => c.Name == company.Name && c.Id != company.Id).Result.Any())
                return null;

            await _companyRepository.Update(company);
            return company;
        }
    }
}
