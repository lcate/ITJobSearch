using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public IEnumerable<JobApplication> JobApplications { get; set; }

        public IEnumerable<UserTest> UserTests { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

    }
}
