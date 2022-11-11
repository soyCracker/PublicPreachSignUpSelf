using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PPSUF.Service.Services;

namespace PPSUF.BlazorServer.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public IActionResult Test()
        {
            return Ok(new { Value = true, ErrorCode = 0, Res = "Good Auth" });
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync()
        {
            /*if (AccountNameArray.SingleOrDefault(x => x==account).Count()==1)
            {

            }*/  
            if(authService.DoLogin("id"))
            {
                var claims = authService.CreateClaimsPrincipal("id");
                await HttpContext.SignInAsync(claims); 
            }
            
            return Ok(new { Value = true, ErrorCode = 0, Res = "Good Auth" });
        }
    }
}