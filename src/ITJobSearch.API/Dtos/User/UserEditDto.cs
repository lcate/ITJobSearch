using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Dtos.User
{
    public class UserEditDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }

    }
}
