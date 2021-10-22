using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Dtos.JobApplications
{
    public class UpdateStatusDto
    {
        public int JobApplicationId { get; set; }

        public int NewStatus { get; set; }
    }
}
