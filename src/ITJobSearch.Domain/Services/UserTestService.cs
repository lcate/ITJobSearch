using ITJobSearch.Domain.Interfaces;
using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Services
{
    public class UserTestService : IUserTestService
    {
        private readonly IUserTestRepository _userTestRepository;

        public UserTestService(IUserTestRepository userTestRepository)
        {
            _userTestRepository = userTestRepository;
        }

        public Task<UserTest> Add(UserTest userTest)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserTest>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserTest> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(UserTest userTest)
        {
            throw new NotImplementedException();
        }

        public Task<UserTest> Update(UserTest userTest)
        {
            throw new NotImplementedException();
        }
    }
}
