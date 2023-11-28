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
    public class PartTypeDAO : IDAO<PartType>
    {
        private SQLContext _sqlContext;
        private const string _selectAllPartType = "Select * FROM parttype;";
        public PartTypeDAO()
        {
            _sqlContext = SQLContext.getInstance();
        }
        public void Create(PartType obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PartType Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<PartType> GetAll()
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_selectAllPartType, connection);
            var reader = command.ExecuteReader();
            List<PartType> parttypes = new List<PartType>();
            while (reader.Read())
            {
                PartType partType = new PartType.Builder().WithId(reader.GetInt32(0)).WithName(reader.GetString(1)).Build();
                parttypes.Add(partType);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return parttypes;
        }

        public void Update(PartType obj)
        {
            throw new NotImplementedException();
        }
    }
}
