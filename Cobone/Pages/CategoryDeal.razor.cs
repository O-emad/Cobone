using Cobone.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Pages
{
    public partial class CategoryDeal
    {
        [ParameterAttribute]
        public string CategoryId { get; set; }

        protected override void OnInitialized()
        {
            
            base.OnInitialized();
        }
    }
}
