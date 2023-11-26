using TPP_PZ1_Darhil_Danylo.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using MySql.Data.MySqlClient;
using TPP_PZ_Darhil_Danylo.DAL.ViewModels;

namespace CourseProject.Controllers
{
    public class CartController : Controller
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; database=coursework2023tkp; user=root; password=root");
        // GET: CartController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BackToCatalog()
        {
            return RedirectToAction(controllerName: "Home", actionName: "ClientPartsCatalog");
        }
        public ActionResult Delete(int id)
        {
            List<CartPartViewModel> CartParts = new List<CartPartViewModel>();
            CartParts = SessionHelper.GetObjectFromJson<List<CartPartViewModel>>(HttpContext.Session, "CartPart");
            //CartParts.Remove(CartParts[id]);
            CartParts.Remove(CartParts.Find(x => x.AutoPart.Id == id));
            SessionHelper.SetObjectAsJson(HttpContext.Session, "CartPart", CartParts);
            return RedirectToAction(controllerName:"ClientParts",actionName:"Cart");
        }
        public ActionResult UpdateCart(int[] quantities)
        {
            List<CartPartViewModel> CartParts = new List<CartPartViewModel>();
            CartParts = SessionHelper.GetObjectFromJson<List<CartPartViewModel>>(HttpContext.Session, "CartPart");
            //CartParts.Remove(CartParts[id]);
            for(int i=0;i< quantities.Length;i++)
            {
                CartParts[i].Quantity = quantities[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "CartPart", CartParts);
            return View("Cart", CartParts);
        }
        public ActionResult SubmitOrder()
        {
            connection.Open();
            List<CartPartViewModel> CartParts = new List<CartPartViewModel>();
            CartParts = SessionHelper.GetObjectFromJson<List<CartPartViewModel>>(HttpContext.Session, "CartPart");
            var insertedorder = "INSERT INTO orders (`statusid`, `createdate`, `updatedate`, `clientid`,`managerid`) VALUES (1, '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 1,1);";
            var command = new MySqlCommand(insertedorder, connection);
            command.ExecuteNonQuery();
            var lastid = command.LastInsertedId;
            foreach (CartPartViewModel part in CartParts)
            {
                string totalprice = (part.Quantity * part.AutoPart.Price).ToString().Replace(',','.');
                insertedorder = "INSERT INTO ordersautoparts (`autopartid`, `orderid`, `partcount`, `price`) VALUES('"+part.AutoPart.Id+"', '"+lastid+"', '"+part.Quantity+"', '"+totalprice+"')";
                command = new MySqlCommand(insertedorder, connection);
                command.ExecuteNonQuery();
            }
            CartParts.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "CartPart", CartParts);
            CartPartViewModel minuspart = new CartPartViewModel(new AutoPart(),-1);
            minuspart.AutoPart.Id = Convert.ToInt32(lastid);
            CartParts.Add(minuspart);
            return View("Cart", CartParts);
        }
    }
}
