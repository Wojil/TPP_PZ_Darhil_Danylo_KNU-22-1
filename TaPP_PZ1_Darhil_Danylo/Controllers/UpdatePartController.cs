using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace TPP_PZ1_Darhil_Danylo.Controllers
{
    public class UpdatePartController : Controller
    {
        PartTypeDAO PartTypeDAO = new PartTypeDAO();
        PartCategoryDAO PartCategoryDAO = new PartCategoryDAO();
        ManufacturerCountryDAO ManufacturerCountryDAO = new ManufacturerCountryDAO();
        ManufacturerBrandDAO ManufacturerBrandDAO = new ManufacturerBrandDAO();
        AutoModelDAO AutoModelDAO = new AutoModelDAO();
        AutoPartDAO AutoPartDAO = new AutoPartDAO();
        public ActionResult UpdatePart(int id)
        {
            PartPropertiesViewModel partProperties = new PartPropertiesViewModel();
            partProperties.ManufacturerBrands = ManufacturerBrandDAO.GetAll();
            partProperties.ManufacturerCountries = ManufacturerCountryDAO.GetAll();
            partProperties.AutoModels = AutoModelDAO.GetAll();
            partProperties.PartCategories = PartCategoryDAO.GetAll();
            partProperties.PartTypes = PartTypeDAO.GetAll();
            partProperties.AutoPart = AutoPartDAO.Get(id);
            return View(partProperties);
        }
        public ActionResult Update(int id, string name, string code, string automodel, string parttype,string partcategory,string brand, string country, string description,decimal price,int quantity)
        {
            if (description == null)
                description = " ";
            AutoPart autopart = new AutoPart.Builder().WithId(id).WithName(name).WithCode(code).WithAutomodel(automodel).WithPartType(parttype).WithPartCategory(partcategory).WithManufacturerBrand(brand).WithManufacturerCountry(country).WithDescription(description).WithPrice(price).WithQuantity(quantity).Build();
            AutoPartDAO.Update(autopart);
            PartPropertiesViewModel configpropertie = null;
            return View("UpdatePart", configpropertie);
        }
    }
}
