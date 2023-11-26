using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ1_Darhil_Danylo.DAL.SQLConnection;
namespace TPP_PZ_Darhil_Danylo.DAL.DAO.DAOImp
{
    public class ManufacturerBrandDAO : IDAO<ManufacturerBrand>
    {
        private SQLContext _sqlContext;
        private const string _selectAllManufacturerBrand = "Select * FROM manufacturerbrand;";

        public ManufacturerBrandDAO()
        {
            _sqlContext = SQLContext.getInstance();
        }

        public void Create(ManufacturerBrand obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ManufacturerBrand Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ManufacturerBrand> GetAll()
        {
            var connection = _sqlContext.GetConnection();
            List<ManufacturerBrand> manufacturerBrands = new List<ManufacturerBrand>();
            var command = new MySqlCommand(_selectAllManufacturerBrand, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                ManufacturerBrand manufacturerBrand = new ManufacturerBrand.Builder().WithId(reader.GetInt32(0)).WithName(reader.GetString(1)).Build();
                manufacturerBrands.Add(manufacturerBrand);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return manufacturerBrands;
        }

        public void Update(ManufacturerBrand obj)
        {
            throw new NotImplementedException();
        }
    }
}
