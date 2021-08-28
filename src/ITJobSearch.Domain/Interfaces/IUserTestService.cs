using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface IUserTestService : IDisposable
    {
        Task<IEnumerable<UserTest>> GetAll();
        Task<UserTest> GetById(int id);
        Task<UserTest> Add(UserTest userTest);
        Task<UserTest> Update(UserTest userTest);
        Task<bool> Remove(UserTest userTest);
    }
}
