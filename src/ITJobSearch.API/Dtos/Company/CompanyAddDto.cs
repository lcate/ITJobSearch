﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Controllers.Dtos
{
    public class CompanyAddDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }

        public string WebURL { get; set; }

        public string UserId { get; set; }

        public string AboutUs { get; set; }

        public string Linkedin { get; set; }

    }
}
