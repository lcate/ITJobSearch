using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        new Task<List<User>> GetAll();

        new Task<User> GetById(int id);
    }
}
