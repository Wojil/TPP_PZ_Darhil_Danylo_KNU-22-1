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
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; database=coursework2023tkp; user=root; password=12345");

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

      /*  public IActionResult ClientPartsCatalog()
        {
            connection.Open();

            var SelectAllAutoParts = "select a.autopartid,a.code, m.automodelid, m.automodelname,c.categoryid,c.categoryname,t.typeid,t.typename,b.brandid,b.brandname,mc.countryid,mc.countryname," +
                                    "a.partname,a.price,a.partdescription,a.quantity " +
                                    "from autoparts a " +
                                    "join partcategory c on a.categoryid = c.categoryid " +
                                    "join parttype t on t.typeid = a.typeid " +
                                    "join automodel m on a.automodelid = m.automodelid " +
                                    "join manufacturerbrand b on b.brandid = a.brandid " +
                                    "join manufacturercountry mc on mc.countryid = a.countryid; ";
            var command = new MySqlCommand(SelectAllAutoParts, connection);
            var reader = command.ExecuteReader();
            List<AutoPart> autoparts = new List<AutoPart>();
            while (reader.Read())
            {
                AutoPart autopart = new AutoPart
                {
                    Id = reader.GetInt32(0),
                    Code = reader.GetString(1),
                    AutoModel = new AutoModel
                    {
                        Id = reader.GetInt32(2),
                        AutoModelName = reader.GetString(3),
                    },
                    PartCategory = new PartCategory
                    {
                        Id = reader.GetInt32(4),
                        CategoryName = reader.GetString(5)
                    },
                    PartType = new PartType
                    {
                        Id = reader.GetInt32(6),
                        TypeName = reader.GetString(7)
                    },
                    ManufacturerBrand = new ManufacturerBrand
                    {
                        Id = reader.GetInt32(8),
                        BrandName = reader.GetString(9)
                    },
                    ManufacturerCountry = new ManufacturerCountry
                    {
                        Id = reader.GetInt32(10),
                        CountryName = reader.GetString(11)
                    },
                    Name = reader.GetString(12),
                    Price = reader.GetDecimal(13),
                    Description = reader.GetString(14),
                    Quantity = reader.GetInt32(15)
                };
                autoparts.Add(autopart);
            }
            reader.Close();
            return View(autoparts);
        }*/
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