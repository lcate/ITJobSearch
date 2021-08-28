using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface ITestService : IDisposable
    {
        Task<IEnumerable<Test>> GetAll();
        Task<Test> GetById(int id);
        Task<Test> Add(Test test);
        Task<Test> Update(Test test);
        Task<bool> Remove(Test test);
    }
}
