using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Controllers.Dtos
{
    public class CompanyResultDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public string UserId { get; set; }

        public int EmployeesFrom { get; set; }

        public int EmployeesTo { get; set; }

        public int YearFounded { get; set; }

        public string Locations { get; set; }
    }
}
