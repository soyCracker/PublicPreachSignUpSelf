using Microsoft.AspNetCore.Components.Authorization;
using PPSUF.Service.Models.Req;
using PPSUF.Service.Services;

namespace PPSUF.BlazorServer.Extension
{
    public class NameAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly AuthService authService;

        public NameAuthenticationStateProvider(AuthService authService)
        {
            this.authService = authService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return await Task.FromResult(new AuthenticationState(await authService.GetUserByToken()));
        }

        public async Task Login(AuthLoginReq userInfo)
        {
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(await authService.ChkUserValid(userInfo))));
        }
    }
}
