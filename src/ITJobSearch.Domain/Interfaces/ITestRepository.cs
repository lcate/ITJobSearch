using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface ITestRepository : IRepository<Test>
    {
        new Task<List<Test>> GetAll();

        new Task<Test> GetById(int id);
    }
}
