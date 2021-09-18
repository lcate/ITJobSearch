using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Domain.Models
{
    public class Company : Entity
    {
        public string Name { get; set; }

        public string WebURL { get; set; }

        public string Logo { get; set; }

        public string UserId { get; set; }

        public IEnumerable<Test> Tests { get; set; }

        public IEnumerable<JobOffer> JobOffers { get; set; }
    }
}
