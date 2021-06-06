using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MailSender.Models;
using MailSender.ViewModels;
using Newtonsoft.Json;
using MailSender.Extensions;

namespace MailSender.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var homeIndexViewModel = new HomeIndexViewModel { PageTitle = "Home" };
            return View(homeIndexViewModel);
        }

        [HttpPost]
        public IActionResult Index(HomeIndexViewModel homeIndexViewModel)
        {
            TempData.Put("model", homeIndexViewModel);
            return RedirectToAction("Mail");
        }


        public IActionResult Mail()
        {
            var homeMailViewModel = new HomeMailViewModel { PageTitle = "Mail" };
            return View(homeMailViewModel);
        }

        [HttpPost]
        public IActionResult Mail(HomeMailViewModel homeMailViewModel)
        {
            var modelData = TempData.Get<HomeIndexViewModel>("model");
            homeMailViewModel.FirstName = modelData.FirstName;
            homeMailViewModel.LastName = modelData.LastName;
            homeMailViewModel.Email = modelData.Email;
            var layoutViewModel = new LayoutViewModel { PageTitle = "Success" };
            return View("Success", layoutViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
