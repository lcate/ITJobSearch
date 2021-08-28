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

        public string Logo { get; set; }
    }
}
