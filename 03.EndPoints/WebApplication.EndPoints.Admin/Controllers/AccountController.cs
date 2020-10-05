using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.EndPoints.Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(string username = "mohsen")
        {
            var claim = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,"1234"),
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Email,"email"),
            };

            var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true,
            };
            await HttpContext.SignInAsync(principal, properties);

            ViewBag.IsSuccess = true;
            return View();
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

    }
}