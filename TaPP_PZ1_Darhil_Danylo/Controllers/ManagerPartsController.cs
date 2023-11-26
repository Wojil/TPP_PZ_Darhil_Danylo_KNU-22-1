using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.PortableExecutable;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ_Darhil_Danylo.DAL.ViewModels;

namespace CourseProject.Controllers
{
    public class ManagerPartsController : Controller
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; database=coursework2023tkp; user=root; password=12345");
        // GET: ManagerPartsController

        public ActionResult GetManagerParts()
        {
            AutoPartDAO ADAO = new AutoPartDAO();
            List<AutoPart> autoparts = ADAO.GetAll();
            return View("ManagerParts",autoparts);
        }

        // POST: ManagerPartsController/Create
        [HttpPost]
        public ActionResult Delete(int id)
        {
            AutoPartDAO ADAO = new AutoPartDAO();
            ADAO.Delete(id);
            return RedirectToAction(controllerName: "ManagerParts", actionName: "GetManagerParts");
        }
        public ActionResult UpdatePart(int id)
        {
            AutoPartDAO ADAO = new AutoPartDAO();
            AutoPart autopart = ADAO.Get(id);
            PartPropertiesViewModel partProperties = new PartPropertiesViewModel();
            partProperties.ManufacturerBrands = GetBrands();
            partProperties.ManufacturerCountries = GetCountries();
            partProperties.AutoModels = GetAutoModels();
            partProperties.PartCategories = GetPartCategories();
            partProperties.PartTypes = GetPartTypes();
            partProperties.AutoPart = autopart;
            return View(partProperties);
        }
        public ActionResult AddPart()
        {
            connection.Open();
            PartPropertiesViewModel partProperties = new PartPropertiesViewModel();
            partProperties.ManufacturerBrands = GetBrands();
            partProperties.ManufacturerCountries = GetCountries();
            partProperties.AutoModels = GetAutoModels();
            partProperties.PartCategories = GetPartCategories();
            partProperties.PartTypes= GetPartTypes();
            return View(partProperties);
        }

        public List<PartType> GetPartTypes()
        {
            var parttype = "Select * FROM parttype;";
            var command = new MySqlCommand(parttype, connection);
            var reader = command.ExecuteReader();
            List<PartType> parttypes=new List<PartType>();
            while (reader.Read())
            {
                PartType partType = new PartType.Builder().WithId(reader.GetInt32(0)).WithName(reader.GetString(1)).Build();
                parttypes.Add(partType);
            }
            reader.Close();
            return parttypes;
        }
        public List<PartCategory> GetPartCategories()
        {
            var partcategory = "Select * FROM partcategory;";
            var command = new MySqlCommand(partcategory, connection);
            var reader = command.ExecuteReader();
            List<PartCategory> partCategories = new List<PartCategory>();
            while (reader.Read())
            {
                PartCategory partCategory = new PartCategory.Builder().WithId(reader.GetInt32(0)).WithName(reader.GetString(1)).Build();
                partCategories.Add(partCategory);
            }
            reader.Close();
            return partCategories;
        }
        public List<ManufacturerBrand> GetBrands()
        {
            List<ManufacturerBrand> manufacturerBrands = new List<ManufacturerBrand>();
            var manufacturerbrand = "Select * FROM manufacturerbrand;";
            var command = new MySqlCommand(manufacturerbrand, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                ManufacturerBrand manufacturerBrand = new ManufacturerBrand.Builder().WithId(reader.GetInt32(0)).WithName(reader.GetString(1)).Build();
                manufacturerBrands.Add(manufacturerBrand);
            }
            reader.Close();
            return manufacturerBrands;
        }
        public List<ManufacturerCountry> GetCountries()
        {
            List<ManufacturerCountry> manufacturerCountries = new List<ManufacturerCountry>();
            var manufacturercountry = "Select * FROM manufacturercountry;";
            var command = new MySqlCommand(manufacturercountry, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                ManufacturerCountry manufacturerCountry = new ManufacturerCountry.Builder().WithId(reader.GetInt32(10)).WithName(reader.GetString(11)).Build();
                manufacturerCountries.Add(manufacturerCountry);
            }
            reader.Close();
            return manufacturerCountries;

        }
        public List<AutoModel> GetAutoModels()
        {
            List<AutoModel> autoModels  = new List<AutoModel>();
            var automodel = "Select * FROM automodel;";
            var command = new MySqlCommand(automodel, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                AutoModel autoModel = new AutoModel.Builder().WithId(reader.GetInt32(0)).WithName(reader.GetString(1)).Build();
                autoModels.Add(autoModel);
            }
            reader.Close();
            return autoModels;
        }
        public ActionResult SearchAutoParts(string searchcriteria)
        {
            connection.Open();
            var SelectAllAutoParts = "select a.autopartid,a.code, m.automodelid, m.automodelname,c.categoryid,c.categoryname,t.typeid,t.typename,b.brandid,b.brandname,mc.countryid,mc.countryname," +
                                    "a.partname,a.price,a.partdescription,a.quantity " +
                                    "from autoparts a " +
                                    "join partcategory c on a.categoryid = c.categoryid " +
                                    "join parttype t on t.typeid = a.typeid " +
                                    "join automodel m on a.automodelid = m.automodelid " +
                                    "join manufacturerbrand b on b.brandid = a.brandid " +
                                    "join manufacturercountry mc on mc.countryid = a.countryid" +
                                    " where a.partname like '%" + searchcriteria + "%' or a.code like '%" + searchcriteria + "%';";
            var command = new MySqlCommand(SelectAllAutoParts, connection);
            var reader = command.ExecuteReader();
            List<AutoPart> autoparts = new List<AutoPart>();
            while (reader.Read())
            {
                AutoPart autopart = new AutoPart.Builder()
                    .WithId(reader.GetInt32(0))
                    .WithCode(reader.GetString(1))
                    .WithAutomodel(reader.GetInt32(2), reader.GetString(3))
                    .WithPartCategory(reader.GetInt32(4), reader.GetString(5))
                    .WithPartType(reader.GetInt32(6), reader.GetString(7))
                    .WithManufacturerBrand(reader.GetInt32(6), reader.GetString(7))
                    .WithManufacturerCountry(reader.GetInt32(10), reader.GetString(11))
                    .WithName(reader.GetString(12))
                    .WithPrice(reader.GetDecimal(13))
                    .WithDescription(reader.GetString(14))
                    .WithQuantity(reader.GetInt32(15)).Build();
                autoparts.Add(autopart);
            }
            reader.Close();
            return View("ManagerParts", autoparts);
        }

    }
}
