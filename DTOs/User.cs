﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    internal class User: BaseDTO
    {
        public string UserCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime Status { get; set;
    }
}
