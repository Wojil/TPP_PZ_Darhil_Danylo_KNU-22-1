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
    public class PartCategoryDAO : IDAO<PartCategory>
    {
        private SQLContext _sqlContext;
        private const string _selectAllPartCategory = "Select * FROM partcategory;";

        public PartCategoryDAO()
        {
            _sqlContext = SQLContext.getInstance();
        }

        public void Create(PartCategory obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PartCategory Get(int id)
        {
            throw new NotImplementedException();

        }

        public List<PartCategory> GetAll()
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_selectAllPartCategory, connection);
            var reader = command.ExecuteReader();
            List<PartCategory> partCategories = new List<PartCategory>();
            while (reader.Read())
            {
                PartCategory partCategory = new PartCategory.Builder().WithId(reader.GetInt32(0)).WithName(reader.GetString(1)).Build();
                partCategories.Add(partCategory);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return partCategories;
        }

        public void Update(PartCategory obj)
        {
            throw new NotImplementedException();
        }
    }
}
