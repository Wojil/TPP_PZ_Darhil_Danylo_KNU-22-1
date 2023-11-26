using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.SQLConnection;
using MySql.Data.MySqlClient;

namespace TPP_PZ_Darhil_Danylo.DAL.DAO.DAOImp
{
    public class AutoModelDAO : IDAO<AutoModel>
    {
        private SQLContext _sqlContext;
        private const string _selectAllAutomodel = "Select * FROM automodel;";

        public AutoModelDAO()
        {
            _sqlContext = SQLContext.getInstance();
        }
        public void Create(AutoModel obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AutoModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<AutoModel> GetAll()
        {
            var connection = _sqlContext.GetConnection();
            List<AutoModel> autoModels = new List<AutoModel>();
            var command = new MySqlCommand(_selectAllAutomodel, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                AutoModel autoModel = new AutoModel.Builder().WithId(reader.GetInt32(0)).WithName(reader.GetString(1)).Build();
                autoModels.Add(autoModel);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return autoModels;
        }

        public void Update(AutoModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
