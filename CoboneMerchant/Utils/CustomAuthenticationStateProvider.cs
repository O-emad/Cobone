using CoboneMerchant.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Utils
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IAccountDataService accountDataService;

        public CustomAuthenticationStateProvider(IAccountDataService accountDataService)
        {
            this.accountDataService = accountDataService ?? throw new ArgumentNullException(nameof(accountDataService));
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await accountDataService.GetAccountDetails();
            if (user is not null && !string.IsNullOrWhiteSpace(user.Email))
            {
                var claims = new Claim(ClaimTypes.Name, user.Email);
                var claimIdentity = new ClaimsIdentity(new[] { claims }, "serverAuth");
                var claimPrinciple = new ClaimsPrincipal(claimIdentity);
                return new AuthenticationState(claimPrinciple);
            }
            else
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
}
