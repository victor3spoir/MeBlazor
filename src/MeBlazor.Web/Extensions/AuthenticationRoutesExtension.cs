using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MeBlazor.Web.Extensions
{
    public static class AuthenticationRoutesExtension
    {
        public static WebApplication MapAuthenticationRoutes(this WebApplication app)
        {

            app.MapGet("/account/logout", async (HttpContext context) =>
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return TypedResults.Redirect("/");
            });
            return app;
        }
    }
}