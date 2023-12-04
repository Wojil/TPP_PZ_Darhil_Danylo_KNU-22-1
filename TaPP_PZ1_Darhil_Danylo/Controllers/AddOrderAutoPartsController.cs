using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Management;
using TPP_PZ_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace TPP_PZ_Darhil_Danylo.Controllers
{
    public class AddOrderAutoPartsController : Controller
    {
        OrderDAO OrderDAO = new OrderDAO();
        AutoPartDAO AutoPartDAO = new AutoPartDAO();
        OrdersAutoPartsDAO OrdersAutoPartsDAO = new OrdersAutoPartsDAO();
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
                OrdersAutoParts ordersAutoParts = new OrdersAutoParts.Builder().WithAutopart(id, quantity, price * quantity/100).WithOrder(OrderDAO.GetLastInsertedOrderId()).Build();
                OrdersAutoPartsDAO.Create(ordersAutoParts);
                serializedOrder = JsonConvert.SerializeObject(order);
                TempData["SerializedOrder"] = serializedOrder;
                return RedirectToAction("AddOrderAutoParts", "AddOrderAutoParts");
            }
            return null;
        }
    }
}
