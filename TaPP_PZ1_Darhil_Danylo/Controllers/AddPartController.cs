using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace CourseProject.Controllers
{
    public class AddPartController : Controller
    {
        PartTypeDAO PartTypeDAO = new PartTypeDAO();
        PartCategoryDAO PartCategoryDAO = new PartCategoryDAO();
        ManufacturerCountryDAO ManufacturerCountryDAO = new ManufacturerCountryDAO();
        ManufacturerBrandDAO ManufacturerBrandDAO = new ManufacturerBrandDAO();
        AutoModelDAO AutoModelDAO = new AutoModelDAO();
        AutoPartDAO AutoPartDAO = new AutoPartDAO();
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
