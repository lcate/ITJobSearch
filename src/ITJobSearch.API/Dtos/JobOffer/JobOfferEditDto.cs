﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Controllers.Dtos
{
    public class JobOfferEditDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Position { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Description { get; set; }

        public string Salary { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string WorkHours { get; set; }
    }
}
