﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class Authorize
    {
            public string? Access_Token { get; set; }
            public int Expires_In { get; set; }
            public string? Token_Type { get; set; }
        
    }
}
