using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Controllers.Dtos
{
    public class CommentResultDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string JobApplicationId { get; set; }

        public string Message { get; set; }
    }
}
