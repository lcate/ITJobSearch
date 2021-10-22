using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Controllers.Dtos
{
    public class JobOfferResultDto
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public string Position { get; set; }

        public string Experience { get; set; }

        public string WorkType { get; set; }

        public string Description { get; set; }

        public string Salary { get; set; }

        public string WorkHours { get; set; }
    }
}
