using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPP_PZ_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;

namespace TPP_PZ_Darhil_Danylo.Controllers
{
    public class UpdateOrderController : Controller
    {
        OrderDAO OrderDAO = new OrderDAO();
        OrderStatusDAO OrderStatusDAO = new OrderStatusDAO();
        ClientDAO ClientDAO = new ClientDAO();
        ManagerDAO ManagerDAO = new ManagerDAO();
        public ActionResult UpdateOrder(int id)
        {
            OrderPropertiesViewModel orderProperties = new OrderPropertiesViewModel();
            orderProperties.clients = ClientDAO.GetAll();
            orderProperties.managers= ManagerDAO.GetAll();
            orderProperties.orderStatuses= OrderStatusDAO.GetAll();
            orderProperties.order = OrderDAO.Get(id);
            return View(orderProperties);
        }
        public ActionResult Update(int id, int statusid, string createdate, string updatedate, string comment, int clientid, int managerid)
        {
            if (comment == null)
                comment = " ";
            /*  AutoPart autopart = new AutoPart.Builder().WithId(id).WithName(name).WithCode(code).WithAutomodel(automodel).WithPartType(parttype).WithPartCategory(partcategory).WithManufacturerBrand(brand).WithManufacturerCountry(country).WithDescription(description).WithPrice(price).WithQuantity(quantity).Build();
              AutoPartDAO.Update(autopart);*/
            OrderPropertiesViewModel orderProperties = null;
            return View("UpdatePart", orderProperties);
        }
    }
}
