using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ_Darhil_Danylo.DAL.DAO.FactoryMethod;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ_Darhil_Danylo.DAL.MementoPattern;
using Microsoft.SqlServer.Management.Smo;
using Newtonsoft.Json;

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
        AutopartCaretaker AutopartCaretaker;
        PartPropertiesViewModel partProperties;
        public UpdatePartController()
        {
            PartTypeDAO = DAOFactory.Create<PartType>();
            PartCategoryDAO = DAOFactory.Create<PartCategory>();
            ManufacturerCountryDAO = DAOFactory.Create<ManufacturerCountry>();
            ManufacturerBrandDAO = DAOFactory.Create<ManufacturerBrand>();
            AutoModelDAO = DAOFactory.Create<AutoModel>();
            string role = System.IO.File.ReadAllText("UserRole.txt");
            AutoPartDAO = DAOFactory.Create<AutoPart>(role);
            AutopartCaretaker = new AutopartCaretaker();
            partProperties = new PartPropertiesViewModel();
        }
        public ActionResult UpdatePart(int id)
        {
            partProperties = GetPartProperties();
            partProperties.AutoPart = AutoPartDAO.Get(id);
            partProperties.StatesCount = AutopartCaretaker.History.Count();
            return View("UpdatePart", partProperties);
        }
        public ActionResult Update(int id, string name, string code, string automodel, string parttype, string partcategory, string brand, string country, string description, decimal price, int quantity)
        {
            string? caretakerHistoryJson = TempData["AutopartCaretaker_History"] as string;

            AutopartCaretaker.History.Push(AutoPartDAO.Get(id).SaveState());
            if (!string.IsNullOrEmpty(caretakerHistoryJson))
            {
                var history = JsonConvert.DeserializeObject<Stack<AutopartMemento>>(caretakerHistoryJson);
                var list = history.AsEnumerable().Reverse().ToList();
                list.ForEach(s => AutopartCaretaker.History.Push(s));
            }
            caretakerHistoryJson = JsonConvert.SerializeObject(AutopartCaretaker.History);
            TempData["AutopartCaretaker_History"] = caretakerHistoryJson;
            if (description == null)
                description = " ";
            AutoPart autopart = new AutoPart.Builder().WithId(id).WithName(name).WithCode(code).WithAutomodel(automodel).WithPartType(parttype).WithPartCategory(partcategory).WithManufacturerBrand(brand).WithManufacturerCountry(country).WithDescription(description).WithPrice(price).WithQuantity(quantity).Build();
            AutoPartDAO.Update(autopart);
            return UpdatePart(id);
        }

        public ActionResult Undo()
        {
            string? caretakerHistoryJson = TempData["AutopartCaretaker_History"] as string;

            if (!string.IsNullOrEmpty(caretakerHistoryJson))
            {
                var history = JsonConvert.DeserializeObject<Stack<AutopartMemento>>(caretakerHistoryJson);
                AutopartCaretaker = new AutopartCaretaker(history);
                AutoPart part = new AutoPart.Builder().WithId(0).Build();
                part.RestoreState(AutopartCaretaker.History.Pop());
                partProperties = GetPartProperties();
                partProperties.AutoPart = part;
                partProperties.StatesCount = AutopartCaretaker.History.Count();
                AutoPartDAO.Update(part);
                caretakerHistoryJson = JsonConvert.SerializeObject(AutopartCaretaker.History);
                TempData["AutopartCaretaker_History"] = caretakerHistoryJson;
            }
            return View("UpdatePart", partProperties);
        }

        public PartPropertiesViewModel GetPartProperties()
        {
            PartPropertiesViewModel partproperties = new PartPropertiesViewModel();
            partproperties.ManufacturerBrands = ManufacturerBrandDAO.GetAll();
            partproperties.ManufacturerCountries = ManufacturerCountryDAO.GetAll();
            partproperties.AutoModels = AutoModelDAO.GetAll();
            partproperties.PartCategories = PartCategoryDAO.GetAll();
            partproperties.PartTypes = PartTypeDAO.GetAll();
            return partproperties;
        }
    }
}
