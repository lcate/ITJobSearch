using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface IUserTestRepository : IRepository<UserTest>
    {
        new Task<List<UserTest>> GetAll();

        new Task<UserTest> GetById(int id);
    }
}
