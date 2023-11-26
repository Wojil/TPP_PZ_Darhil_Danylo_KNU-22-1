using TPP_PZ1_Darhil_Danylo.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using TPP_PZ_Darhil_Danylo.DAL.ViewModels;

namespace CourseProject.Controllers
{
    public class ClientPartsController : Controller
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; database=coursework2023tkp; user=root; password=12345");

        public ActionResult AddToCart(int id)
        {
            AutoPart autopart=SelectAutoPart(id);
            List<CartPartViewModel> CartParts=new List<CartPartViewModel>();
            string Cart = HttpContext.Session.GetString("CartPart");
            if(Cart==null)
            {
                CartParts.Add(new CartPartViewModel(autopart,1));
                SessionHelper.SetObjectAsJson(HttpContext.Session, "CartPart", CartParts);
            }
            else
            {
                CartParts = SessionHelper.GetObjectFromJson<List<CartPartViewModel>>(HttpContext.Session, "CartPart");
                int i = Exists(id, CartParts);
                if(i==-1)
                {
                    CartParts.Add(new CartPartViewModel(autopart, 1));
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "CartPart", CartParts);
                }
                else
                {
                    CartParts[i].Quantity++;
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "CartPart", CartParts);
                }
            }
            return RedirectToAction(controllerName: "Home", actionName: "ClientPartsCatalog");
        }
        public int Exists(int id, List<CartPartViewModel> CartParts)
        {
            int result = -1;
            for(int i=0;i<CartParts.Count;i++)
            {
                if (CartParts[i].AutoPart.Id==id)
                    result = i;
            }
            return result;
        }
        public AutoPart SelectAutoPart(int id)
        {
            connection.Open();
            var selectautopart = "select a.autopartid,a.code, m.automodelid, m.automodelname,c.categoryid,c.categoryname,t.typeid,t.typename,b.brandid,b.brandname,mc.countryid,mc.countryname," +
                "a.partname,a.price,a.partdescription,a.quantity " +
                "from autoparts a " +
                "join partcategory c on a.categoryid = c.categoryid " +
                "join parttype t on t.typeid = a.typeid " +
                "join automodel m on a.automodelid = m.automodelid " +
                "join manufacturerbrand b on b.brandid = a.brandid " +
                "join manufacturercountry mc on mc.countryid = a.countryid where a.autopartid = " + id + "; ";
            var command = new MySqlCommand(selectautopart, connection);
            var reader = command.ExecuteReader();
            AutoPart autopart=null;
            while (reader.Read())
            {
                autopart = new AutoPart
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
            }
            reader.Close();
            return autopart;
        }
        public ActionResult Cart()
        {
            List<CartPartViewModel> CartParts = new List<CartPartViewModel>();
            CartParts = SessionHelper.GetObjectFromJson<List<CartPartViewModel>>(HttpContext.Session, "CartPart");
            //return Redirect("/Shared/Cart");//CartParts
            return View(CartParts);
        }
        // GET: ClientPartsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClientPartsController/Details/5
        public ActionResult ClientOrders(int changeid = 0)
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
                " join manager m on m.managerid=o.managerid where c.clientid=1;";
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
                Change = changeid,
            };
            connection.Close();
            return View(listmodel);
        }

        // GET: ClientPartsController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult SearchAutoParts(string searchcriteria)
        {
            connection.Open();
            var SelectAllAutoParts = "select a.autopartid,a.code, m.automodelid, m.automodelname,c.categoryid,c.categoryname,t.typeid,t.typename,b.brandid,b.brandname,mc.countryid,mc.countryname," +
                                    "a.partname,a.price,a.partdescription,a.quantity " +
                                    "from autoparts a " +
                                    "join partcategory c on a.categoryid = c.categoryid " +
                                    "join parttype t on t.typeid = a.typeid " +
                                    "join automodel m on a.automodelid = m.automodelid " +
                                    "join manufacturerbrand b on b.brandid = a.brandid " +
                                    "join manufacturercountry mc on mc.countryid = a.countryid" +
                                    " where a.partname like '%"+ searchcriteria + "%' or a.code like '%"+searchcriteria+"%';";
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
            return View("ClientPartsCatalog",autoparts);
        }

        // GET: ClientPartsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientPartsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientPartsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientPartsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
