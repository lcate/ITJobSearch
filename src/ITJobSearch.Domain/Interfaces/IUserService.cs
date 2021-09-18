using ITJobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSearch.Domain.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IEnumerable<AppUser>> GetAll();
        Task<AppUser> GetById(int id);
        Task<AppUser> Add(AppUser user);
        Task<AppUser> Update(AppUser user);
        Task<bool> Remove(AppUser user);
    }
}
