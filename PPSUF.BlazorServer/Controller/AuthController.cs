using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PPSUF.Service.Models.Req;
using PPSUF.Service.Models.Res;
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
        public async Task<MessageModel<bool>> Login(AuthLoginReq req)
        {
            if(authService.DoLogin("id"))
            {
                var claims = authService.CreateClaimsPrincipal("id");
                await HttpContext.SignInAsync(claims); 
                return new MessageModel<bool>
                {
                    Msg = "Good",
                    Data = true
                };
            }
            return new MessageModel<bool>
            {
                Success = false,
                Msg = "Bad",
                Data = false
            };
        }
    }
}