using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ1_Darhil_Danylo.DAL.SQLConnection;

namespace TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp
{
    public class OrderDAO : IDAO<Order>
    {
        private SQLContext _sqlContext;
        private const string _selectOrderByIdQuery = "SELECT o.orderid, s.statusid,s.statusname," +
            "o.createdate,o.updatedate,o.comment,o.managerid,m.name, m.surname, m.patronymic," +
 "o.clientid,c.name,c.surname,c.patronymic,m.login,c.login" +
 " FROM orders o join orderstatus s on s.statusid=o.statusid " +
 " join client c on c.clientid=o.clientid" +
 " join manager m on m.managerid=o.managerid where o.orderid =@id ;";
        private const string _searchOrderByCriteriaQuery = "SELECT o.orderid, s.statusid,s.statusname," +
    "o.createdate,o.updatedate,o.comment,o.managerid,m.name, m.surname, m.patronymic," +
"o.clientid,c.name,c.surname,c.patronymic,m.login,c.login" +
" FROM orders o join orderstatus s on s.statusid=o.statusid " +
" join client c on c.clientid=o.clientid" +
" join manager m on m.managerid=o.managerid where c.name like @criteria or m.name like @criteria or s.statusname like @criteria or m.login like @criteria or c.login like @criteria;";
        private const string _selectAllOrders = "SELECT o.orderid, s.statusid,s.statusname," +
    "o.createdate,o.updatedate,o.comment,o.managerid,m.name, m.surname, m.patronymic," +
"o.clientid,c.name,c.surname,c.patronymic,m.login,c.login" +
" FROM orders o join orderstatus s on s.statusid=o.statusid " +
" join client c on c.clientid=o.clientid" +
" join manager m on m.managerid=o.managerid;";
        private const string _updateOrderQuery = "UPDATE orders SET `statusid` = @statusid, " +
            "`createdate` =@createdate, `updatedate` = @updatedate, `comment` = @comment,clientid=@clientid," +
            " `managerid` = @managerid WHERE (`orderid` = @orderid);";
        private const string _insertOrderQuery = "INSERT INTO `orders` (`statusid`, `createdate`," +
            " `updatedate`, `comment`, `clientid`, `managerid`) VALUES (@statusid, @createdate, @updatedate," +
            " @comment, @clientid, @managerid);";
        private const string _deleteOrderQuery = "delete from orders where (orderid=@id);";
        private const string _getLastInsertedId = "SELECT LAST_INSERT_ID();";
        public int GetLastInsertedOrderId()
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_getLastInsertedId, connection);
            int resultid = Convert.ToInt32(command.ExecuteScalar());
            _sqlContext.CloseConnection();

            return resultid;
        }
        public OrderDAO()
        {
            _sqlContext = SQLContext.getInstance();
        }
        public void Create(Order obj)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_insertOrderQuery, connection);
            command.Parameters.AddWithValue("@statusid", obj.Status.Id);
            command.Parameters.AddWithValue("@createdate", obj.CreateDate);
            command.Parameters.AddWithValue("@updatedate", obj.UpdateDate);
            command.Parameters.AddWithValue("@comment", obj.Comment);
            command.Parameters.AddWithValue("@clientid", obj.Client.Id);
            command.Parameters.AddWithValue("@managerid", obj.Manager.Id);
            command.ExecuteNonQuery();
            _sqlContext.CloseConnection();
        }

        public void Delete(int id)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_deleteOrderQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            _sqlContext.CloseConnection();
        }

        public Order Get(int id)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_selectOrderByIdQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            reader.Read();
            Order order = new Order.Builder()
                .WithId(reader.GetInt32(0))
                .WithStatus(reader.GetInt32(1), reader.GetString(2))
                .WithCreateDate(reader.GetDateTime(3))
                .WithUpdateDate(reader.GetDateTime(4))
                .WithComment(reader.GetString(5))
                .WithManager(reader.GetInt32(6),reader.GetString(7),reader.GetString(8),reader.GetString(9),reader.GetString(14))
                .WithClient(reader.GetInt32(10), reader.GetString(11), reader.GetString(12), reader.GetString(13),reader.GetString(15))
                .Build();
            reader.Close();
            _sqlContext.CloseConnection();
            return order;
        }

        public List<Order> GetAll()
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_selectAllOrders, connection);
            var reader = command.ExecuteReader();
            List<Order> orders = new List<Order>();
            while (reader.Read())
            {
                Order order = new Order.Builder()
                .WithId(reader.GetInt32(0))
                .WithStatus(reader.GetInt32(1), reader.GetString(2))
                .WithCreateDate(reader.GetDateTime(3))
                .WithUpdateDate(reader.GetDateTime(4))
                .WithComment(reader.GetString(5))
                .WithManager(reader.GetInt32(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(14))
                .WithClient(reader.GetInt32(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(15))
                .Build();
                orders.Add(order);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return orders;
        }

        public List<Order> SearchByCriteria(string criteria)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_selectOrderByIdQuery, connection);
            command.Parameters.AddWithValue("@criteria", "%"+criteria+"%");
            var reader = command.ExecuteReader();
            List<Order> orders = new List<Order>();
            while (reader.Read())
            {
                Order order = new Order.Builder()
                .WithId(reader.GetInt32(0))
                .WithStatus(reader.GetInt32(1), reader.GetString(2))
                .WithCreateDate(reader.GetDateTime(3))
                .WithUpdateDate(reader.GetDateTime(4))
                .WithComment(reader.GetString(5))
                .WithManager(reader.GetInt32(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(14))
                .WithClient(reader.GetInt32(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(15))
                .Build();
                orders.Add(order);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return orders;
        }

        public void Update(Order obj)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_updateOrderQuery, connection);
            command.Parameters.AddWithValue("@orderid", obj.Id);
            command.Parameters.AddWithValue("@statusid", obj.Status.Id);
            command.Parameters.AddWithValue("@createdate", obj.CreateDate);
            command.Parameters.AddWithValue("@updatedate", obj.UpdateDate);
            command.Parameters.AddWithValue("@comment", obj.Comment);
            command.Parameters.AddWithValue("@managerid", obj.Manager.Id);
            command.Parameters.AddWithValue("@clientid", obj.Client.Id);
            command.ExecuteNonQuery();
            _sqlContext.CloseConnection();
        }
    }
}
