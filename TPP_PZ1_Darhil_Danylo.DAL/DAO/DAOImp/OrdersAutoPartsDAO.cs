using Microsoft.SqlServer.Management.Smo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ_Darhil_Danylo.DAL.ObserverPattern.Interfaces;
using TPP_PZ_Darhil_Danylo.DAL.ObserverPattern.Classes;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ1_Darhil_Danylo.DAL.SQLConnection;

namespace TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp
{
    public class OrdersAutoPartsDAO : IDAO<OrdersAutoParts>
    {
        private OrderDAO OrderDAO=new OrderDAO();
        private SQLContext _sqlContext;
        private const string _selectAllOrdersQuery = "SELECT oa.autopartid,oa.orderid,oa.partcount,oa.price,a.partname,a.code,a.price," +
         "a.quantity, s.statusid,s.statusname,o.createdate,o.updatedate,o.comment,o.managerid,m.name, m.surname," +
         "o.clientid,c.name,c.surname,c.patronymic,c.phone,c.email,c.adress,c.login,m.login,m.patronymic,m.phone,m.email" +
         " FROM ordersautoparts oa join autoparts a on oa.autopartid=a.autopartid" +
         " join orders o on oa.orderid=o.orderid" +
         " join orderstatus s on s.statusid=o.statusid " +
         " join client c on c.clientid=o.clientid" +
         " join manager m on m.managerid=o.managerid;";
        private const string _searchOrdersByCriteriaQuery = "SELECT oa.autopartid,oa.orderid,oa.partcount,oa.price,a.partname,a.code,a.price," +
 "a.quantity, s.statusid,s.statusname,o.createdate,o.updatedate,o.comment,o.managerid,m.name, m.surname," +
 "o.clientid,c.name,c.surname,c.patronymic,c.phone,c.email,c.adress,c.login,m.login,m.patronymic,m.phone,m.email" +
 " FROM ordersautoparts oa join autoparts a on oa.autopartid=a.autopartid" +
 " join orders o on oa.orderid=o.orderid" +
 " join orderstatus s on s.statusid=o.statusid " +
 " join client c on c.clientid=o.clientid" +
 " join manager m on m.managerid=o.managerid where oa.orderid like @searchcriteria or" +
            " concat(c.name,' ',c.surname,' ',c.patronymic) like @searchcriteria ;";
        private const string _deleteOrdersAutoPartsQuery = "delete from ordersautoparts where (orderid=@id);";
        private const string _insertOrdersAutoPartsQuery = "insert into ordersautoparts (autopartid,orderid,partcount,price) values(@autopartid,@orderid,@partcount,@price);";
        private const string _getLastInsertedId = "SELECT LAST_INSERT_ID();";

        public void Create(OrdersAutoParts obj)
        {
            if(obj.Order.Id==0)
            {
                obj.Order.Id = GetLastInsertedOrderId();
            }
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_insertOrdersAutoPartsQuery, connection);
            command.Parameters.AddWithValue("@autopartid", obj.AutoPart.Id);
            command.Parameters.AddWithValue("@orderid", obj.Order.Id);
            command.Parameters.AddWithValue("@partcount", obj.AutoPart.SelectedPartCount);
            command.Parameters.AddWithValue("@price", obj.AutoPart.Price);
            command.ExecuteNonQuery();
            _sqlContext.CloseConnection();
            /*Console.WriteLine(DateTime.Now + " Було додано новий запис до таблиці OrdersAutoParts. Об'єкт який був доданий до БД:\n");
            NotifyObservers(obj);*/
        }
        public int GetLastInsertedOrderId()
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_getLastInsertedId, connection);
            int resultid = Convert.ToInt32(command.ExecuteScalar());
            _sqlContext.CloseConnection();

            return resultid;
        }

        public OrdersAutoPartsDAO()
        {
            _sqlContext = SQLContext.getInstance();
            //OnModelCreated += (x) => { Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(x)); };
        }
        public void Delete(int id)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_deleteOrdersAutoPartsQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            _sqlContext.CloseConnection();
            OrderDAO.Delete(id);
            Console.WriteLine(DateTime.Now + " Було видалено запис з таблиці OrdersAutoParts з id=" + id+"\n");
        }

        public OrdersAutoParts Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrdersAutoParts> GetAll()
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_selectAllOrdersQuery, connection);
            var reader = command.ExecuteReader();
            List<OrdersAutoParts> OrdersAutoParts = new List<OrdersAutoParts>();
            while (reader.Read())
            {
                OrdersAutoParts orderAutoPart = new OrdersAutoParts.Builder()
                    .WithAutopart(reader.GetInt32(0),
                    reader.GetInt32(2),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetDecimal(6),
                    reader.GetInt32(7))
                    .WithOrder(reader.GetInt32(1),
                    reader.GetInt32(8),
                    reader.GetString(9),
                    reader.GetDateTime(10),
                    reader.GetDateTime(11),
                    reader.IsDBNull(12) ? " " : reader.GetString(12),
                    reader.GetInt32(16),
                    reader.GetString(23),
                    reader.GetString(17),
                    reader.GetString(18),
                    reader.GetString(19),
                    reader.GetString(20),
                    reader.GetString(21),
                    reader.GetString(22),
                    reader.GetInt32(13),
                    reader.GetString(24),
                    reader.GetString(14),
                    reader.GetString(15),
                    reader.GetString(25),
                    reader.GetString(26),
                    reader.GetString(27))
                    .WithPrice(reader.GetInt32(3)).Build();
                OrdersAutoParts.Add(orderAutoPart);
            }
            reader.Close();
            _sqlContext.CloseConnection();
           /* Console.WriteLine(DateTime.Now + " Було отримано список елементів з таблиці OrdersAutoParts. Перший елемент з переліку:\n");
            NotifyObservers(OrdersAutoParts[0]);*/
            return OrdersAutoParts;
        }

        public List<OrdersAutoParts> SearchByCriteria(string criteria)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_searchOrdersByCriteriaQuery, connection);
            command.Parameters.AddWithValue("@searchcriteria", "%" + criteria + "%");
            var reader = command.ExecuteReader();
            List<OrdersAutoParts> OrdersAutoParts = new List<OrdersAutoParts>();
            while (reader.Read())
            {
                OrdersAutoParts orderAutoPart = new OrdersAutoParts.Builder()
                    .WithAutopart(reader.GetInt32(0),
                    reader.GetInt32(2),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetDecimal(6),
                    reader.GetInt32(7))
                    .WithOrder(reader.GetInt32(1),
                    reader.GetInt32(8),
                    reader.GetString(9),
                    reader.GetDateTime(10),
                    reader.GetDateTime(11),
                    reader.IsDBNull(12) ? " " : reader.GetString(12),
                    reader.GetInt32(16),
                    reader.GetString(23),
                    reader.GetString(17),
                    reader.GetString(18),
                    reader.GetString(19),
                    reader.GetString(20),
                    reader.GetString(21),
                    reader.GetString(22),
                    reader.GetInt32(13),
                    reader.GetString(24),
                    reader.GetString(14),
                    reader.GetString(15),
                    reader.GetString(25),
                    reader.GetString(26),
                    reader.GetString(27))
                    .WithPrice(reader.GetInt32(3)).Build();
                OrdersAutoParts.Add(orderAutoPart);
            }
            reader.Close();
            _sqlContext.CloseConnection();
          /*  Console.WriteLine(DateTime.Now+ " Було відібрано список елементів з таблиці OrdersAutoParts. Перший елемент з переліку:\n");
            NotifyObservers(OrdersAutoParts[0]);*/
            return OrdersAutoParts;
        }

        public void Update(OrdersAutoParts obj)
        {
            throw new NotImplementedException();
        }
    }
}
