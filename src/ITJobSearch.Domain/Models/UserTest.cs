using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Domain.Models
{
    public class UserTest : Entity
    {
        public string Feedback { get; set; }

        public int TestId { get; set; }

        public Test Test { get; set; }

        public AppUser User { get; set; }
    }
}
