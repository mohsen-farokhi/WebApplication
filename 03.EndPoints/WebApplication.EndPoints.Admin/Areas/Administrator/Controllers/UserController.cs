using Microsoft.AspNetCore.Mvc;
using ViewModels.Areas.Administrator.User;

namespace WebApplication.EndPoints.Admin.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateViewModel();

            return View(viewModel);
        }
    }
}