using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Domain.Models
{
    public class User : Entity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Type { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public IEnumerable<JobApplication> JobApplications { get; set; }

        public IEnumerable<UserTest> UserTests { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
