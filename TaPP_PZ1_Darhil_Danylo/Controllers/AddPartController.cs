using TPP_PZ1_Darhil_Danylo.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CourseProject.Controllers
{
    public class AddPartController : Controller
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; database=coursework2023tkp; user=root; password=12345");
        // GET: AddPartController
        public ActionResult Index()
        {
            return View();
        }
        // GET: AddPartController/Create
        public ActionResult Create(string name, string code, string automodel, string parttype,string partcategory,string brand, string country, string description,decimal price,int quantity)
        {
            if (description == null)
                description = " ";
            connection.Open();
            var selectautopart = "INSERT INTO autoparts (`code`, `automodelid`, `categoryid`, `typeid`, `brandid`, `countryid`, " +
                "`partname`, `price`, `partdescription`, `quantity`) " +
                "VALUES ('"+code+"', (select automodelid from automodel where automodelname='"+automodel+"')," +
                " (select categoryid from partcategory where categoryname='"+partcategory+"')," +
                " (select typeid from parttype where typename='" + parttype+"')," +
                " (select brandid from manufacturerbrand where brandname='"+brand+"')," +
                " (select countryid from manufacturercountry where countryname='" + country + "')," +
                " '"+name+"', '"+price+"', '"+description+"', '"+quantity+"');";
            var command = new MySqlCommand(selectautopart, connection);
            command.ExecuteNonQuery();
            PartProperties configpropertie = null;
            return View("AddPart", configpropertie);
        }
    }
}
