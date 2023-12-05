using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ_Darhil_Danylo.DAL.DAO.FactoryMethod;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;

namespace CourseProject.Controllers
{
    public class ManagerOrdersController : Controller
    {
        DAOFactory DAOFactory = new DAOFactory();
        private readonly IDAO<OrdersAutoParts> OrdersAutoPartsDAO;
        public ManagerOrdersController()
        {
            OrdersAutoPartsDAO = DAOFactory.Create<OrdersAutoParts>();
        }

        public ActionResult GetOrders()
        {
            List<OrdersAutoParts> ordersAutoParts = OrdersAutoPartsDAO.GetAll();
            return View("ManagerOrders",ordersAutoParts);
        }
        public ActionResult SearchOrders(string searchcriteria)
        {
            List<OrdersAutoParts> ordersAutoParts = OrdersAutoPartsDAO.SearchByCriteria(searchcriteria);
            return View("ManagerOrders", ordersAutoParts);
        }
        public ActionResult Delete(int id)
        {
            OrdersAutoPartsDAO.Delete(id);
            return RedirectToAction(controllerName: "ManagerOrders", actionName: "GetOrders");
        }
    }
}
