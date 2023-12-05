using TPP_PZ1_Darhil_Danylo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Data.Common;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.X509;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;

namespace CourseProject.Controllers
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

        public IActionResult Privacy()
        {
                return View();
        }
        public IActionResult ManagerMenu()
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