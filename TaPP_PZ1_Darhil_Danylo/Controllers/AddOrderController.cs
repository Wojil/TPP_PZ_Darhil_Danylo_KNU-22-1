using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TPP_PZ_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;

namespace TPP_PZ_Darhil_Danylo.Controllers
{
    public class AddOrderController : Controller
    {
        OrderStatusDAO OrderStatusDAO = new OrderStatusDAO();
        ClientDAO ClientDAO = new ClientDAO();
        ManagerDAO ManagerDAO = new ManagerDAO();

        public ActionResult AddOrder()
        {
            OrderPropertiesViewModel orderProperties = new OrderPropertiesViewModel();
            orderProperties.Clients = ClientDAO.GetAll();
            orderProperties.Managers = ManagerDAO.GetAll();
            orderProperties.OrderStatuses = OrderStatusDAO.GetAll();
            return View(orderProperties);
        }
        public ActionResult Create(int orderid, int statusid, string createdate, string updatedate, string comment, int clientid, int managerid)
        {
            if (comment == null)
                comment = " ";
            Order order= new Order.Builder().WithId(orderid).WithStatus(statusid).WithCreateDate(Convert.ToDateTime(createdate)).WithUpdateDate(Convert.ToDateTime(updatedate)).WithComment(comment).WithClient(clientid).WithManager(managerid).Build();
            string serializedOrder = JsonConvert.SerializeObject(order);
            TempData["SerializedOrder"] = serializedOrder;
            return RedirectToAction("AddOrderAutoParts", "AddOrderAutoParts");
        }

    }
}
