using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public class BrowserService
    {
        
        public static event EventHandler<int>? Resize;
        private static int browserWidth;
        private static int browserHeight;

        [JSInvokable("SetBrowserDimensions")]
        public static void SetBrowserDimensions(int jsBrowserWidth, int jsBrowserHeight)
        {
            browserWidth = jsBrowserWidth;
            browserHeight = jsBrowserHeight;
            // For simplicity, we're just using the new width
            Resize?.Invoke(new object(), jsBrowserWidth);
        }
    }
}
