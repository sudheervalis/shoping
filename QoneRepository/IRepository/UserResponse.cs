﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QoneRepository.IRepository
{
   
        public class UserResponse : BaseResponse
        {
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime CreationDate { get; set; }
        }
}
