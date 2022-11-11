using Microsoft.AspNetCore.Authentication.Cookies;
using PPSUF.Service.Base;

namespace PPSUF.BlazorServer.Extension
{
    public static class ConfigureExtension
    {
        public static void SetAuth(this IServiceCollection sc)
        {
            sc.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            //網站本身的Cookie - based Authentication
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.Redirect(new PathString(Constant.LOGIN_URL));
                    return Task.CompletedTask;
                };
                // ExpireTimeSpan與Cookie.MaxAge都要設定
                options.ExpireTimeSpan = TimeSpan.FromHours(6);
                options.Cookie.MaxAge = options.ExpireTimeSpan;
                //登入後過期時間內没有進行操作就會過期;false有操作還是會過期
                options.SlidingExpiration = false;
            });
        }
    }
}
