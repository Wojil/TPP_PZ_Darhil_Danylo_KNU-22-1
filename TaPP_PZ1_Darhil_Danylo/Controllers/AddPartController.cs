using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ_Darhil_Danylo.DAL.DAO.FactoryMethod;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;

namespace CourseProject.Controllers
{
    public class AddPartController : Controller
    {
        DAOFactory DAOFactory = new DAOFactory();
        private readonly IDAO<PartType> PartTypeDAO;
        private readonly IDAO<PartCategory> PartCategoryDAO;
        private readonly IDAO<ManufacturerCountry> ManufacturerCountryDAO;
        private readonly IDAO<ManufacturerBrand> ManufacturerBrandDAO;
        private readonly IDAO<AutoModel> AutoModelDAO;
        private readonly IDAO<AutoPart> AutoPartDAO;
        public AddPartController()
        {
            PartTypeDAO = DAOFactory.Create<PartType>();
            PartCategoryDAO = DAOFactory.Create<PartCategory>();
            ManufacturerCountryDAO = DAOFactory.Create<ManufacturerCountry>();
            ManufacturerBrandDAO = DAOFactory.Create<ManufacturerBrand>();
            AutoModelDAO = DAOFactory.Create<AutoModel>();
            string role = System.IO.File.ReadAllText("UserRole.txt");
            AutoPartDAO = DAOFactory.Create<AutoPart>(role);
        }

        public ActionResult AddPart()
        {
            PartPropertiesViewModel partProperties = new PartPropertiesViewModel();
            partProperties.ManufacturerBrands = ManufacturerBrandDAO.GetAll();
            partProperties.ManufacturerCountries = ManufacturerCountryDAO.GetAll();
            partProperties.AutoModels = AutoModelDAO.GetAll();
            partProperties.PartCategories = PartCategoryDAO.GetAll();
            partProperties.PartTypes = PartTypeDAO.GetAll();
            return View(partProperties);
        }
        public ActionResult Create(string name, string code, string automodel, string parttype,string partcategory,string brand, string country, string description,decimal price,int quantity)
        {
            if (description == null)
                description = " ";
            AutoPart autopart = new AutoPart.Builder().WithName(name).WithCode(code).WithAutomodel(automodel).WithPartType(parttype).WithPartCategory(partcategory).WithManufacturerBrand(brand).WithManufacturerCountry(country).WithDescription(description).WithPrice(price).WithQuantity(quantity).Build();
            AutoPartDAO.Create(autopart);
            PartPropertiesViewModel configpropertie = null;
            return View("AddPart", configpropertie);
        }
    }
}
