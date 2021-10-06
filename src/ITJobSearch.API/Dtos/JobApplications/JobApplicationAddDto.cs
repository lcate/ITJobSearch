using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Dtos
{
    public class JobApplicationAddDto
    {
        public int JobOfferId { get; set; }

        public string UserId { get; set; }

        public string ImgPath { get; set; }
    }
}
