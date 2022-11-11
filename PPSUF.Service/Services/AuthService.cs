using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PPSUF.Service.Services
{
    public class AuthService
    {
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
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            return new ClaimsPrincipal(claimsIdentity);
        }

        public bool DoLogin(string id)
        {     
            return true;
        }
    }
}