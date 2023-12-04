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
    public class OrderStatusDAO : IDAO<OrderStatus>
    {
        private SQLContext _sqlContext;
        private const string _selectAllStatusesQuery = "select statusid, statusname from orderstatus";
        public OrderStatusDAO()
        {
            _sqlContext = SQLContext.getInstance();
        }
        public void Create(OrderStatus obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OrderStatus Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderStatus> GetAll()
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_selectAllStatusesQuery, connection);
            var reader = command.ExecuteReader();
            List<OrderStatus> orders = new List<OrderStatus>();
            while (reader.Read())
            {
                OrderStatus order = new OrderStatus.Builder()
                    .WithId(reader.GetInt32(0))
                    .WithName(reader.GetString(1)).Build();
                orders.Add(order);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return orders;

        }

        public List<OrderStatus> SearchByCriteria(string criteria)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderStatus obj)
        {
            throw new NotImplementedException();
        }
    }
}
