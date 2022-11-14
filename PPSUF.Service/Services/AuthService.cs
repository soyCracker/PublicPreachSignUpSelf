using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using PPSUF.Service.Models.Req;
using System.Security.Claims;

namespace PPSUF.Service.Services
{
    public class AuthService
    {
        private readonly ISessionStorageService sessionStorage;

        public AuthService(ISessionStorageService sessionStorage)
        {
            this.sessionStorage = sessionStorage;
        }

        public ClaimsPrincipal CreateClaimsPrincipal(string id)
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

        public async Task<ClaimsPrincipal> GetUserByToken()
        {
            string userToken = await sessionStorage.GetItemAsync<string>("UserToken");
            if (!string.IsNullOrEmpty(userToken))
            {
                return CreateClaimsPrincipal(userToken);
            }
            return new ClaimsPrincipal(new ClaimsIdentity());
        }

        public async Task<ClaimsPrincipal> ChkUserValid(AuthLoginReq req)
        {
            string[] AccountNameArray =
            {
                "賴育暉","魏筱芬"
            };
            if (AccountNameArray.Where(x => x==req.Username).Count()==1)
            {
                await sessionStorage.SetItemAsync("UserToken", req.Username);
                return CreateClaimsPrincipal(req.Username);
            }
            return new ClaimsPrincipal(new ClaimsIdentity());
        }
    }
}