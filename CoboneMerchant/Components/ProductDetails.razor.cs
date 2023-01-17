using CoboneMerchant.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Components
{
    public partial class ProductDetails
    {
        [Parameter] public FullProductInfo Product { get; set; }
    }
}
