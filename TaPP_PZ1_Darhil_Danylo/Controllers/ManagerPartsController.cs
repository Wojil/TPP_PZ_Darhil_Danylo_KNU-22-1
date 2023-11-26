using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.PortableExecutable;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ_Darhil_Danylo.DAL.DAO.DAOImp;

namespace CourseProject.Controllers
{
    public class ManagerPartsController : Controller
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; database=coursework2023tkp; user=root; password=12345");
        AutoPartDAO AutoPartDAO = new AutoPartDAO();
        PartTypeDAO PartTypeDAO = new PartTypeDAO();
        PartCategoryDAO PartCategoryDAO = new PartCategoryDAO();
        ManufacturerCountryDAO ManufacturerCountryDAO=new ManufacturerCountryDAO();
        ManufacturerBrandDAO ManufacturerBrandDAO = new ManufacturerBrandDAO();
        AutoModelDAO AutoModelDAO = new AutoModelDAO();
        public ActionResult GetAutoParts()
        {
            List<AutoPart> autoparts = AutoPartDAO.GetAll();
            return View("ManagerParts",autoparts);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            AutoPartDAO.Delete(id);
            return RedirectToAction(controllerName: "ManagerParts", actionName: "GetAutoParts");
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

        public ActionResult AddPart()
        {
            connection.Open();
            PartPropertiesViewModel partProperties = new PartPropertiesViewModel();
            partProperties.ManufacturerBrands = ManufacturerBrandDAO.GetAll();
            partProperties.ManufacturerCountries = ManufacturerCountryDAO.GetAll();
            partProperties.AutoModels = AutoModelDAO.GetAll();
            partProperties.PartCategories = PartCategoryDAO.GetAll();
            partProperties.PartTypes= PartTypeDAO.GetAll();
            return View(partProperties);
        }

        public ActionResult SearchAutoParts(string searchcriteria)
        {
            List<AutoPart> autoparts = AutoPartDAO.SearchAutoPart(searchcriteria);
            return View("ManagerParts", autoparts);
        }

    }
}
