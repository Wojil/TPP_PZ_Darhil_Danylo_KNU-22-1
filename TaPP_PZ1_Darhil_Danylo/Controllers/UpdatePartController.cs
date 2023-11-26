using TPP_PZ1_Darhil_Danylo.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CourseProject.Controllers
{
    public class UpdatePartController : Controller
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; database=coursework2023tkp; user=root; password=12345");
        // GET: AddPartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AddPartController/Details/5
        public ActionResult BackToAllParts()
        {
            return RedirectToAction(controllerName: "ManagerMenu", actionName: "ManagerAutoParts");
        }

        public ActionResult Update(int id, string name, string code, string automodel, string parttype,string partcategory,string brand, string country, string description,decimal price,int quantity)
        {
            if (description == null)
                description = " ";
            connection.Open();
            var selectautopart = "UPDATE autoparts SET `code` ='" + code+ "'," +
                "`automodelid` = (select automodelid from automodel where automodelname='" + automodel+"')," +
                " `categoryid` =(select categoryid from partcategory where categoryname='" + partcategory+"')," +
                " `typeid` =(select typeid from parttype where typename='" + parttype+"')," +
                " `brandid` =(select brandid from manufacturerbrand where brandname='" + brand+"')," +
                " `countryid` = (select countryid from manufacturercountry where countryname='" + country + "')," +
                " `partname` = '" + name+ "', `price` ='" + price+ "',`partdescription` = '" + description+ "',`quantity` = '" + quantity+ "' " +
                " WHERE `autopartid` = '"+id+"';";
            var command = new MySqlCommand(selectautopart, connection);
            command.ExecuteNonQuery();
            PartProperties configpropertie = null;
            return View("UpdatePart", configpropertie);
        }
    }
}
