using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public Task<Test> Add(Test test)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Test>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Test> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Test test)
        {
            throw new NotImplementedException();
        }

        public Task<Test> Update(Test test)
        {
            throw new NotImplementedException();
        }
    }
}
