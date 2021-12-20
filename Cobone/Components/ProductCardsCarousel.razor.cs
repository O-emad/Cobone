using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Components
{
    public partial class ProductCardsCarousel :IAsyncDisposable
    {
        [Parameter] public List<string> Source { get; set; }
        private List<List<string>> Grids { get; set; } = new List<List<string>>();
        [Inject] public IJSRuntime? JS { get; set; }
        [Inject] IBreakpointService? BreakpointListener { get; set; }
        private Guid _subscriptionId;
        private Breakpoint breakPoint;


        public int SelectedIndex { get; set; } = 0;

        public int Xs { get; set; } = 12;
        public int Sm { get; set; } = 6;
        public int Md { get; set; } = 6;
        public int Lg { get; set; } = 4;
        public int Xl { get; set; } = 3;
        public int Xxl { get; set; } = 3;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
                var subscriptionResult = await BreakpointListener.Subscribe(async (breakpoint) =>
                {
                    breakPoint = breakpoint;
                    PopulateCarouselGrid();
                    await JS.InvokeVoidAsync("carouselFitContent");
                    await InvokeAsync(StateHasChanged);
                }, new ResizeOptions
                {
                    ReportRate = 250,
                    NotifyOnBreakpointOnly = true,
                });

                breakPoint = subscriptionResult.Breakpoint;
                _subscriptionId = subscriptionResult.SubscriptionId;
                PopulateCarouselGrid();
                await JS.InvokeVoidAsync("carouselFitContent");
                StateHasChanged();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private void PopulateCarouselGrid()
        {
            SelectedIndex = 0;   
            Xs = 12;
            Sm = Md = 6;
            Lg = 4;
            Xl = Xxl = 3;
            Grids = new List<List<string>>();
            int productsPerGrid = 1;
            if (Source.Count == 0)
                return;
            if(Source.Count == 1)
            {
                Sm = Md = Lg = Xl = Xxl = 12;
                productsPerGrid = 1;
            }else if(Source.Count == 2)
            {
                Lg = Xl = Xxl = 6;
                productsPerGrid=2;
            }else if (Source.Count == 3)
            {
                Xl = Xxl = 4;
                productsPerGrid=3;
            }

            switch (breakPoint)
            {
                case Breakpoint.Xs:
                    productsPerGrid = 1;
                    break;
                case Breakpoint.Sm:
                case Breakpoint.Md:
                    if(Source.Count > 1)
                        productsPerGrid = 2;
                    break;
                case Breakpoint.Lg:
                    if(Source.Count > 2)
                        productsPerGrid = 3;   
                    break;
                case Breakpoint.Xl:
                case Breakpoint.Xxl:
                    if(Source.Count > 3)
                        productsPerGrid = 4;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < Source.Count; i+=productsPerGrid)
            {
                Grids.Add(Source.Skip(i).Take(productsPerGrid).ToList());
            }
            //StateHasChanged();
        }

        public async ValueTask DisposeAsync() => await BreakpointListener.Unsubscribe(_subscriptionId);
    }
}
