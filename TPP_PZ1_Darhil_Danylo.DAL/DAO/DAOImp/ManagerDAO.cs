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
    public class ManagerDAO : IDAO<Manager>
    {
        private SQLContext _sqlContext;
        private const string _selectAllManagersQuery = "select managerid,login,password,name,surname," +
            "patronymic,phone,email from manager";
        public ManagerDAO()
        {
            _sqlContext = SQLContext.getInstance();
        }
        public void Create(Manager obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Manager Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Manager> GetAll()
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_selectAllManagersQuery, connection);
            var reader = command.ExecuteReader();
            List<Manager> managers = new List<Manager>();
            while (reader.Read())
            {
                Manager manager = new Manager.Builder()
                    .WithId(reader.GetInt32(0))
                    .WithLogin(reader.GetString(1))
                    .WithPassword(reader.GetString(2))
                    .WithName(reader.GetString(3))
                    .WithSurname(reader.GetString(4))
                    .WithPatronymic(reader.GetString(5))
                    .WithPhone(reader.GetString(6))
                    .WithEmail(reader.GetString(7)).Build();
                managers.Add(manager);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return managers;
        }

        public List<Manager> SearchByCriteria(string criteria)
        {
            throw new NotImplementedException();
        }

        public void Update(Manager obj)
        {
            throw new NotImplementedException();
        }
    }
}
