using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Domain.Models
{
    public class JobApplication : Entity
    {
        public int Status { get; set; } //enum

        public string UserId { get; set; }

        public int JobOfferId { get; set; }

        public AppUser User { get; set; }

        public JobOffer JobOffer { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
