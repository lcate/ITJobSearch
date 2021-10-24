using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public string ProfilePicture { get; set; }

        public string Linkedin { get; set; }

        public string AboutMe { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public IEnumerable<JobApplication> JobApplications { get; set; }

        public IEnumerable<UserTest> UserTests { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

    }
}
