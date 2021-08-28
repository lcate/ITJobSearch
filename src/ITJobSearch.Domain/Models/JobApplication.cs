using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Domain.Models
{
    public class JobApplication : Entity
    {
        public int Status { get; set; } //enum

        public int UserId { get; set; }

        public int JobOfferId { get; set; }

        public User User { get; set; }

        public JobOffer JobOffer { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
