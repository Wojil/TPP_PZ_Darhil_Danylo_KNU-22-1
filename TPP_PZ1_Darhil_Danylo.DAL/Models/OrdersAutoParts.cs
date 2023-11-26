using Microsoft.IdentityModel.Tokens;
using System.Reflection.PortableExecutable;

namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public class OrdersAutoParts
    {
        public AutoPart AutoPart { get; set; } = null!;
        public Order Order { get; set; } = null!;
        public double Price { get; set; }
        private OrdersAutoParts() { }

        class Builder
        {
            private OrdersAutoParts _ordersAutoParts = new OrdersAutoParts();
            public Builder WithAutopart(int id, string code, int automodelid, string automodelname,
                int partcategoryid, string partcategoryname, int parttypeid, string parttypename,
                int manufacturerbrandid, string manufacturerbrandname,
                int manufacturercountryid, string manufacturercountryname,
                string name, decimal price, string description, int quantity)
            {
                _ordersAutoParts.AutoPart = new AutoPart.Builder()
                .WithId(id)
                .WithCode(code)
                .WithAutomodel(automodelid, automodelname)
                .WithPartCategory(partcategoryid, partcategoryname)
                .WithPartType(parttypeid, parttypename)
                .WithManufacturerBrand(manufacturerbrandid, manufacturerbrandname)
                .WithManufacturerCountry(manufacturercountryid, manufacturercountryname)
                .WithName(name)
                .WithPrice(price)
                .WithDescription(description)
                .WithQuantity(quantity).Build();

                return this;
            }
            public Builder WithOrder(int id, int statusid,string statusname,DateTime createdate,
                DateTime updatedate, string comment,int clientid,string login, string password,
                string name,string surname, string patronymic, string phone,string email,
                string adress,int managerid, string managerlogin, string managerpassword,
                string managername,string managersurname, string managerpatronymic,
                string managerphone,string manageremail)
            {
                _ordersAutoParts.Order=new Order.Builder()
                    .WithId(id)
                    .WithComment(comment)
                    .WithCreateDate(createdate)
                    .WithUpdateDate(updatedate)
                    .WithStatus(statusid, statusname)
                    .WithClient(clientid,login,password,name,surname,patronymic,phone,email,adress)
                    .WithManager(managerid,managerlogin,managerpassword, managername, managersurname,managerpatronymic, managerphone, manageremail)
                    .Build();
                return this;
            }
            public Builder WithPrice(double Price)
            {
                _ordersAutoParts.Price = Price;
                return this;
            }
            public OrdersAutoParts Build()
            {
                if ((_ordersAutoParts.Order)==null || (_ordersAutoParts.AutoPart)==null)
                {
                    throw new InvalidOperationException("Деталі замовлення або автозапчастина яка лежить у замовленні є null");
                }
                else return _ordersAutoParts;
            }

        }
    }
}
