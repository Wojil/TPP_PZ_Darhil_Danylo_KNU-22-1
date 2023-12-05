using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPP_PZ_Darhil_Danylo.DAL.DAO.FactoryMethod;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace TPP_PZ_Darhil_Danylo.Controllers
{
    public class ManagerClientsController : Controller
    {
        DAOFactory DAOFactory = new DAOFactory();
        private readonly IDAO<Client> ClientDAO;
        public ManagerClientsController()
        {
            ClientDAO = DAOFactory.Create<Client>();
        }
        public ActionResult GetClients()
        {
            List<Client> clients = ClientDAO.GetAll();
            return View("ManagerClients", clients);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ClientDAO.Delete(id);
            return RedirectToAction(controllerName: "ManagerClients", actionName: "GetClients");
        }
        public ActionResult SearchClients(string searchcriteria)
        {
            List<Client> clients = ClientDAO.SearchByCriteria(searchcriteria);
            return View("ManagerClients", clients);
        }
    }
}
