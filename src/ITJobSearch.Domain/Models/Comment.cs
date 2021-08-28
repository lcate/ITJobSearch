using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Domain.Models
{
    public class Comment : Entity
    {
        public string Message { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int JobApplicationId { get; set; }

        public JobApplication JobApplication { get; set; }
    }
}
