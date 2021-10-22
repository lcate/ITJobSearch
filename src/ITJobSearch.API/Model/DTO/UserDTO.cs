using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Model.DTO
{
    public class UserDTO
    {
        public UserDTO(string fullName, string email, string userName, DateTime dateCreated, string profilePicture, string role)
        {
            FullName = fullName;
            Email = email;
            UserName = userName;
            DateCreated = dateCreated;
            Role = role;
            ProfilePicture = profilePicture;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Token { get; set; }
        public string ProfilePicture { get; set; }
        public string Role { get; set; }
        public int CompanyId { get; set; }

    }
}
