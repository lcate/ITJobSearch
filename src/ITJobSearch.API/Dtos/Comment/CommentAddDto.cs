using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Controllers.Dtos
{
    public class CommentAddDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int JobApplicationId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string UserEmail { get; set; }

        public string Message { get; set; }

        public string File { get; set; }

    }
}
