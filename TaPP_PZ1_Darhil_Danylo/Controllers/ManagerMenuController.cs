using TPP_PZ1_Darhil_Danylo.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using TPP_PZ_Darhil_Danylo.DAL.ViewModels;

namespace CourseProject.Controllers
{
    public class ManagerMenuController : Controller
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; database=coursework2023tkp; user=root; password=12345");
        // GET: ManagerMenuController
        public ActionResult ManagerParts()
        {
            connection.Open();

            var SelectAllAutoParts = "select a.autopartid,a.code, m.automodelid, m.automodelname,c.categoryid,c.categoryname,t.typeid,t.typename,b.brandid,b.brandname,mc.countryid,mc.countryname," +
                                    "a.partname,a.price,a.partdescription,a.quantity " +
                                    "from autoparts a " +
                                    "join partcategory c on a.categoryid = c.categoryid " +
                                    "join parttype t on t.typeid = a.typeid " +
                                    "join automodel m on a.automodelid = m.automodelid " +
                                    "join manufacturerbrand b on b.brandid = a.brandid " +
                                    "join manufacturercountry mc on mc.countryid = a.countryid; ";
            var command = new MySqlCommand(SelectAllAutoParts, connection);
            var reader = command.ExecuteReader();
            List<AutoPart> autoparts = new List<AutoPart>();
            while (reader.Read())
            {
                AutoPart autopart = new AutoPart
                {
                    Id = reader.GetInt32(0),
                    Code = reader.GetString(1),
                    AutoModel = new AutoModel
                    {
                        Id = reader.GetInt32(2),
                        AutoModelName = reader.GetString(3),
                    },
                    PartCategory = new PartCategory
                    {
                        Id = reader.GetInt32(4),
                        CategoryName = reader.GetString(5)
                    },
                    PartType = new PartType
                    {
                        Id = reader.GetInt32(6),
                        TypeName = reader.GetString(7)
                    },
                    ManufacturerBrand = new ManufacturerBrand
                    {
                        Id = reader.GetInt32(8),
                        BrandName = reader.GetString(9)
                    },
                    ManufacturerCountry = new ManufacturerCountry
                    {
                        Id = reader.GetInt32(10),
                        CountryName = reader.GetString(11)
                    },
                    Name = reader.GetString(12),
                    Price = reader.GetDecimal(13),
                    Description = reader.GetString(14),
                    Quantity = reader.GetInt32(15)
                };
                autoparts.Add(autopart);
            }
            reader.Close();
            return View("ManagerParts", autoparts);

        }
        public ActionResult ManagerOrders(int changeid=0)
        {
            List<OrdersAutoParts> ordersAutoParts = new List<OrdersAutoParts>();
            List<OrderStatus> statusList = new List<OrderStatus>();
            connection.Open();
            var SelectAllStatuses = "SELECT * FROM orderstatus;";
            var SelectAllOrders = "SELECT oa.autopartid,oa.orderid,oa.partcount,oa.price,a.partname,a.code,a.price," +
                "a.quantity, s.statusid,s.statusname,o.createdate,o.updatedate,o.comment,o.managerid,m.name, m.surname," +
                "o.clientid,c.name,c.surname,c.patronymic,c.phone,c.email,c.adress" +
                " FROM ordersautoparts oa join autoparts a on oa.autopartid=a.autopartid" +
                " join orders o on oa.orderid=o.orderid" +
                " join orderstatus s on s.statusid=o.statusid " +
                " join client c on c.clientid=o.clientid" +
                " join manager m on m.managerid=o.managerid;";
            MySqlCommand command = new MySqlCommand(SelectAllStatuses, connection);
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
                    Id= reader.GetInt32(0),
                    SelectedPartCount=reader.GetInt32(2),
                    Name=reader.GetString(4),
                    Code=reader.GetString(5),
                    Price=reader.GetDecimal(6),
                    Quantity=reader.GetInt32(7),
                };

                Order order = new Order
                {
                    Id = reader.GetInt32(1),
                    Status = new OrderStatus
                    {
                        Id = reader.GetInt32(8),
                        Name = reader.GetString(9),
                    },
                    CreateDate=reader.GetDateTime(10),
                    UpdateDate=reader.GetDateTime(11),
                    Comment=reader.IsDBNull(12) ? " " : reader.GetString(12),
                    Manager =new Manager
                    {
                        Id=reader.GetInt32(13),
                        Name=reader.GetString(14),
                        Surname=reader.GetString(15),
                    },
                   Client= new Client
                    {
                        Id = reader.GetInt32(16),
                        Name = reader.GetString(17),
                        Surname = reader.GetString(18),
                        Patronymic=reader.GetString(19),
                        Phone=reader.GetString(20),
                        Email=reader.GetString(21),
                        Adress=reader.GetString(22),
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
                Change = changeid,
            };
            connection.Close();
            return View(listmodel);
        }
    }
}
