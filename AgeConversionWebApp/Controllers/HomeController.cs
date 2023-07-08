using AgeConversionWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgeConversionWebApp.Controllers
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
            return View();
        }

        [HttpPost]
        public IActionResult CalculateAge(int day, int month, int year)
        {
            DateTime birthDate = new DateTime(year, month, day);
            DateTime currentDate = DateTime.Now;

            int age = currentDate.Year - birthDate.Year;

            // Check if the birth date hasn't occurred yet in the current year
            if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }

            ViewBag.Age = age;

            return View("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}