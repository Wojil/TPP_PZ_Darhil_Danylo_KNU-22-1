using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Management;
using TPP_PZ_Darhil_Danylo.DAL.DAO.FactoryMethod;
using TPP_PZ_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace TPP_PZ_Darhil_Danylo.Controllers
{
    public class AddOrderAutoPartsController : Controller
    {
        DAOFactory DAOFactory = new DAOFactory();
        private readonly IDAO<Order> OrderDAO;
        private readonly IDAO<AutoPart> AutoPartDAO;
        private readonly IDAO<OrdersAutoParts> OrdersAutoPartsDAO;
        public AddOrderAutoPartsController()
        {
            OrderDAO = DAOFactory.Create<Order>();
            AutoPartDAO = DAOFactory.Create<AutoPart>();
            OrdersAutoPartsDAO = DAOFactory.Create<OrdersAutoParts>();
        }
        public ActionResult AddOrderAutoParts()
        {
                List<AutoPart> autoparts = AutoPartDAO.GetAll();
                return View("AddOrderAutoParts", autoparts);
        }
        public ActionResult SearchAutoParts(string searchcriteria)
        {
            List<AutoPart> autoparts = AutoPartDAO.SearchByCriteria(searchcriteria);
            return View("AddOrderAutoParts", autoparts);
        }
        public ActionResult Create(int id, decimal price, int quantity)
        {
            if (TempData.TryGetValue("SerializedOrder", out object serializedOrderObj) && serializedOrderObj is string serializedOrder)
            {
                Order order = JsonConvert.DeserializeObject<Order>(serializedOrder);
                if (order.Status.Id != -1)
                {
                    OrderDAO.Create(order);
                    order.Status.Id = -1;
                }
                OrdersAutoParts ordersAutoParts = new OrdersAutoParts.Builder().WithAutopart(id, quantity, price * quantity/100).WithOrder(0).Build();
                OrdersAutoPartsDAO.Create(ordersAutoParts);
                serializedOrder = JsonConvert.SerializeObject(order);
                TempData["SerializedOrder"] = serializedOrder;
                return RedirectToAction("AddOrderAutoParts", "AddOrderAutoParts");
            }
            return null;
        }
    }
}
