using Microsoft.AspNetCore.Components.Rendering;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Components
{
    public class CustomMudRadio<T> : MudRadio<T>
    {
        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {

            

            base.BuildRenderTree(__builder);


        }
    }
}
