using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Components
{
    public class CustomBreadcrumbItem : BreadcrumbItem
    {
        public CustomBreadcrumbItem(string text, string href, EventCallback<MouseEventArgs> ev, bool disabled = false, string icon = null) : base(text, href, disabled, icon)
        {
            OnClick = ev;
        }

        public EventCallback<MouseEventArgs> OnClick { get; set; }
    }
}
