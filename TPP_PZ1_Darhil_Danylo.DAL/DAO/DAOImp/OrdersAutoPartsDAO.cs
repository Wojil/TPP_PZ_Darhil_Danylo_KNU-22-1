using Microsoft.SqlServer.Management.Smo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ1_Darhil_Danylo.DAL.SQLConnection;

namespace TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp
{
    public class OrdersAutoPartsDAO : IDAO<OrdersAutoParts>
    {
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
        private const string _deleteOrderQuery = "delete from orders where (orderid=@id);";
        private const string _deleteOrdersAutopartsQuery = "delete from ordersautoparts where (orderid=@id);";

        public void Create(OrdersAutoParts obj)
        {
            throw new NotImplementedException();
        }
        public OrdersAutoPartsDAO()
        {
            _sqlContext = SQLContext.getInstance();
        }
        public void Delete(int id)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_deleteOrdersAutopartsQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
             command = new MySqlCommand(_deleteOrderQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            _sqlContext.CloseConnection();
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
            return OrdersAutoParts;
        }

        public void Update(OrdersAutoParts obj)
        {
            throw new NotImplementedException();
        }
    }
}
