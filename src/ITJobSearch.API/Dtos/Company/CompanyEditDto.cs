using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Controllers.Dtos
{
    public class CompanyEditDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }

        public string URL { get; set; }

        public int EmployeesFrom { get; set; }

        public int EmployeesTo { get; set; }

        public int YearFounded { get; set; }

        public string Locations { get; set; }

        public string ProfilePicture { get; set; }

        public string UserId { get; set; }

        public string AboutUs { get; set; }

        public string Address { get; set; }

        public string Linkedin { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }
    }
}
