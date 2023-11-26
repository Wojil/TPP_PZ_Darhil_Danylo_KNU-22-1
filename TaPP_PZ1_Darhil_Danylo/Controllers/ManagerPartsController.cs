using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.PortableExecutable;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;

namespace CourseProject.Controllers
{
    public class ManagerPartsController : Controller
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; database=coursework2023tkp; user=root; password=12345");
        // GET: ManagerPartsController

        public ActionResult GetManagerParts()
        {
            AutoPartsDAO ADAO = new AutoPartsDAO();
            List<AutoPart> autoparts = ADAO.GetAll();
            return View("ManagerParts",autoparts);
        }

        // POST: ManagerPartsController/Create
        [HttpPost]
        public ActionResult Delete(int id)
        {
            AutoPartsDAO ADAO = new AutoPartsDAO();
            ADAO.Delete(id);
            return RedirectToAction(controllerName: "ManagerParts", actionName: "GetManagerParts");
        }
        public ActionResult UpdatePart(int id)
        {
            AutoPartsDAO ADAO = new AutoPartsDAO();
            AutoPart autopart = ADAO.Get(id);
            PartProperties partProperties = new PartProperties();
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
            PartProperties partProperties = new PartProperties();
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
                PartType partType = new PartType
                {
                    Id = reader.GetInt32(0),
                    TypeName = reader.GetString(1)
                };
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
                PartCategory partCategory = new PartCategory
                {
                    Id = reader.GetInt32(0),
                    CategoryName = reader.GetString(1)
                };
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
                ManufacturerBrand manufacturerBrand = new ManufacturerBrand
                {
                    Id = reader.GetInt32(0),
                    BrandName = reader.GetString(1)
                };
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
                ManufacturerCountry manufacturerCountry = new ManufacturerCountry
                {
                    Id = reader.GetInt32(0),
                    CountryName = reader.GetString(1)
                };
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
                AutoModel autoModel = new AutoModel
                {
                    Id = reader.GetInt32(0),
                    AutoModelName = reader.GetString(1)
                };
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
            return View("ManagerParts", autoparts);
        }

    }
}
