﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAS.Domain.Responses.Account
{
  public  class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
