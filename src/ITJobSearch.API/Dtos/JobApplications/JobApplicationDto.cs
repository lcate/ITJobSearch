using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Dtos
{
    public class JobApplicationDto
    {
        public int JobOfferId { get; set; }

        public string UserEmail { get; set; }

        public string ImgPath { get; set; }
    }
}
