﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITJobSearch.API.Model.BindingModel
{
    public class AddUpdateRegisterUserBindingModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string WebURL { get; set; }
        public string Logo { get; set; }
        public string Linkedin { get; set; }
        public string AboutUs { get; set; }

    }
}
