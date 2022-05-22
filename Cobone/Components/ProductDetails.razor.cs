using Cobone.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Components
{
    public partial class ProductDetails
    {
        [Parameter] public FullProductInfo Product { get; set; }
    }
}
