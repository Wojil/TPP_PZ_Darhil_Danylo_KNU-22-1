using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using TPP_PZ_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace CourseProject.Controllers
{
    public class ManagerOrdersController : Controller
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; database=coursework2023tkp; user=root; password=root");
        // GET: ManagerOrdersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManagerOrdersController/Details/5
        public ActionResult ChangeStatus(int id, string statusname)
        {
            connection.Open();
            var updateorder = "UPDATE orders SET `statusid` = " +
                "(select statusid from orderstatus where statusname='" + statusname + "')," +
                " `managerid` = '2', `updatedate`='" + DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE (`orderid` = '" + id + "');";
            var command = new MySqlCommand(updateorder, connection);
            if (statusname == "Відправлено")
            {
               /* var changequantity = "UPDATE autoparts SET `quantity` =quantity-o.orders.ordersautoparts " +
    "(select statusid from orderstatus where statusname='" + statusname + "')," +
    " `managerid` = '2', `updatedate`='" + DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE (`orderid` = '" + id + "');";
               */
            }
            command.ExecuteNonQuery();
            List<OrdersAutoParts> ordersAutoParts = new List<OrdersAutoParts>();
            List<OrderStatus> statusList = new List<OrderStatus>();
            var SelectAllStatuses = "SELECT * FROM orderstatus;";
            var SelectAllOrders = "SELECT oa.autopartid,oa.orderid,oa.partcount,oa.price,a.partname,a.code,a.price," +
                "a.quantity, s.statusid,s.statusname,o.createdate,o.updatedate,o.comment,o.managerid,m.name, m.surname," +
                "o.clientid,c.name,c.surname,c.patronymic,c.phone,c.email,c.adress" +
                " FROM ordersautoparts oa join autoparts a on oa.autopartid=a.autopartid" +
                " join orders o on oa.orderid=o.orderid" +
                " join orderstatus s on s.statusid=o.statusid " +
                " join client c on c.clientid=o.clientid" +
                " join manager m on m.managerid=o.managerid;";
            command = new MySqlCommand(SelectAllStatuses, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                OrderStatus status = new OrderStatus
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                };
                statusList.Add(status);
            }
            reader.Close();
            command = new MySqlCommand(SelectAllOrders, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                AutoPart autoPart = new AutoPart
                {
                    Id = reader.GetInt32(0),
                    SelectedPartCount = reader.GetInt32(2),
                    Name = reader.GetString(4),
                    Code = reader.GetString(5),
                    Price = reader.GetDecimal(6),
                    Quantity = reader.GetInt32(7),
                };

                Order order = new Order
                {
                    Id = reader.GetInt32(1),
                    Status = new OrderStatus
                    {
                        Id = reader.GetInt32(8),
                        Name = reader.GetString(9),
                    },
                    CreateDate = reader.GetDateTime(10),
                    UpdateDate = reader.GetDateTime(11),
                    Comment = reader.IsDBNull(12) ? " " : reader.GetString(12),
                    Manager = new Manager
                    {
                        Id = reader.GetInt32(13),
                        Name = reader.GetString(14),
                        Surname = reader.GetString(15),
                    },
                    Client = new Client
                    {
                        Id = reader.GetInt32(16),
                        Name = reader.GetString(17),
                        Surname = reader.GetString(18),
                        Patronymic = reader.GetString(19),
                        Phone = reader.GetString(20),
                        Email = reader.GetString(21),
                        Adress = reader.GetString(22),
                    },
                };

                OrdersAutoParts ordersAutoPart = new OrdersAutoParts
                {
                    Price = reader.GetInt32(3),
                    AutoPart = autoPart,
                    Order = order,
                };
                ordersAutoParts.Add(ordersAutoPart);
            }
            reader.Close();
            OrdersAutoPartsViewModel listmodel = new OrdersAutoPartsViewModel
            {
                OrdersAutoParts = ordersAutoParts,
                OrdersStatuses = statusList,
                Change = id,
            };
            connection.Close();

            return View("ManagerOrders", listmodel);
        }

        // GET: ManagerOrdersController/Create
    }
}
