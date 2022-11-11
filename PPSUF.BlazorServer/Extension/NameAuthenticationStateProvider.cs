using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace PPSUF.BlazorServer.Extension
{
    public class NameAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonymous = new ClaimsIdentity();

            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }

        private ClaimsPrincipal CreateClaimsPrincipal(string id)
        {
            //取得使用者roles
            string[] roles = { "user" };
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Account", id));
            claims.Add(new Claim("DisplayName", id));
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return new ClaimsPrincipal(claimsIdentity);
        }

        public async Task DoLogin(string id)
        {
            await ProtectedLocalStore.SetAsync("user", id);
            var user = CreateClaimsPrincipal(id);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
