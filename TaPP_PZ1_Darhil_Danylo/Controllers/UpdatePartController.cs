using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ_Darhil_Danylo.DAL.DAO.FactoryMethod;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;

namespace TPP_PZ1_Darhil_Danylo.Controllers
{
    public class UpdatePartController : Controller
    {
        DAOFactory DAOFactory = new DAOFactory();
        private readonly IDAO<PartType> PartTypeDAO;
        private readonly IDAO<PartCategory> PartCategoryDAO;
        private readonly IDAO<ManufacturerCountry> ManufacturerCountryDAO;
        private readonly IDAO<ManufacturerBrand> ManufacturerBrandDAO;
        private readonly IDAO<AutoModel> AutoModelDAO;
        private readonly IDAO<AutoPart> AutoPartDAO;
        public UpdatePartController()
        {
            PartTypeDAO = DAOFactory.Create<PartType>();
            PartCategoryDAO = DAOFactory.Create<PartCategory>();
            ManufacturerCountryDAO = DAOFactory.Create<ManufacturerCountry>();
            ManufacturerBrandDAO = DAOFactory.Create<ManufacturerBrand>();
            AutoModelDAO = DAOFactory.Create<AutoModel>();
            AutoPartDAO = DAOFactory.Create<AutoPart>();
        }
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
