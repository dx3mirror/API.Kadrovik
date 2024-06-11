using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using API.ProjectKadrovik.ClaimRule.Interface;

namespace API.ProjectKadrovik.ClaimRule
{
    public class SignInDefault : ISignInDefault
    {
        public async Task SignInAsync(HttpContext httpContext, string username)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, username),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                IsPersistent = false,
                RedirectUri = "/Login/Index",
            };

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }
    }
}
