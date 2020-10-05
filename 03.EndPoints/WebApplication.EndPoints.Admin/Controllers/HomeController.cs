using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ViewModels;
using ViewModels.Home;

namespace WebApplication.EndPoints.Admin.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        //[Authorize]
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel viewModel)
        {
            return View(viewModel);
        }

        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            var result = new List<WeatherForecast>();
            result.Add(new WeatherForecast
            {
                Date = System.DateTime.Now,
                Summary = "Freezing",
                TemperatureC = 1
            });
            result.Add(new WeatherForecast
            {
                Date = System.DateTime.Now.AddDays(-1),
                Summary = "Freezing2",
                TemperatureC = 2
            });

            return result;
        }

        public IActionResult ChangeLanguage(string id = "fa-IR")//(int id)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(id)),//(new RequestCulture(new CultureInfo(id))),
                new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });

            return RedirectToAction("Index");
            //return Redirect(Request.Headers["Refere"].ToString());

        }
    }
}