﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class CategoryProducts
    {
        public Category? Category { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
