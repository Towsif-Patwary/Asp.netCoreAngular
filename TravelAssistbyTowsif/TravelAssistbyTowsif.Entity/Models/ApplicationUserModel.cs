﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAssistbyTowsif.Entity.Models
{
    public class ApplicationUserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Preference { get; set; }
    }
}
