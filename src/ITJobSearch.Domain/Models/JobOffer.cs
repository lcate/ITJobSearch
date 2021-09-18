using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Domain.Models
{
    public class JobOffer : Entity
    {
        public string Position { get; set; }

        public string Salary { get; set; }

        public string Description { get; set; }

        public string WorkHours { get; set; }

        public Company Company { get; set; }

        public IEnumerable<JobApplication> JobApplications { get; set; }
    }
}
