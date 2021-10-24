using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Dtos.User
{
    public class UserEditDto
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string ProfilePicture { get; set; }

        public string Linkedin { get; set; }

        public string AboutMe { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
