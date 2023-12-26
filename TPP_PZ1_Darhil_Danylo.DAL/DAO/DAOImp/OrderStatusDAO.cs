using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ_Darhil_Danylo.DAL.ObserverPattern.Classes;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ1_Darhil_Danylo.DAL.SQLConnection;

namespace TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp
{
    public class OrderStatusDAO : /*ConsoleObservable<OrderStatus>, */IDAO<OrderStatus>
    {
        private SQLContext _sqlContext;
        private const string _selectAllStatusesQuery = "select statusid, statusname from orderstatus";
        public OrderStatusDAO()
        {
            _sqlContext = SQLContext.getInstance();
           // OnModelCreated += (x) => { Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(x));};
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
            /*Console.WriteLine(DateTime.Now + " Було отримано список елементів з таблиці OrderStatus. Перший елемент з переліку:\n");
            NotifyObservers(orders[0]);*/
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
