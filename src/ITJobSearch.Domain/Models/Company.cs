using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Domain.Models
{
    public class Company : Entity
    {
        public string Name { get; set; }

        public string WebURL { get; set; }

        public int EmployeesFrom { get; set; }

        public int EmployeesTo { get; set; }

        public int YearFounded { get; set; }

        public string Locations { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public IEnumerable<Test> Tests { get; set; }

        public IEnumerable<JobOffer> JobOffers { get; set; }
    }
}
