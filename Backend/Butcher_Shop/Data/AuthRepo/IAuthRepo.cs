﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.AuthRepo
{
    public interface IAuthRepo
    {
        public Task<string> Authenticate(string username, string password);
    }
}
