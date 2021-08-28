using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Domain.Models
{
    public class Test : Entity
    {
        public string TestText { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public IEnumerable<UserTest> UserTests { get; set; }
    }
}
