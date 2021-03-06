using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Domain.Models
{
    public class Comment : Entity
    {
        public string Message { get; set; }

        public string File { get; set; }

        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public int JobApplicationId { get; set; }

        public JobApplication JobApplication { get; set; }
    }
}
