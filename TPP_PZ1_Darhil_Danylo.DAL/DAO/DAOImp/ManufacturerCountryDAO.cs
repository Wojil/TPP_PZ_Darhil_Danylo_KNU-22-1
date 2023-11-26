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
    public class ManufacturerCountryDAO : IDAO<ManufacturerCountry>
    {
        private SQLContext _sqlContext;
        private const string _selectAllManufacturerCountry = "Select * FROM manufacturercountry;";

        public ManufacturerCountryDAO()
        {
            _sqlContext = SQLContext.getInstance();
        }

        public void Create(ManufacturerCountry obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ManufacturerCountry Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ManufacturerCountry> GetAll()
        {
            var connection = _sqlContext.GetConnection();
            List<ManufacturerCountry> manufacturerCountries = new List<ManufacturerCountry>();
            var command = new MySqlCommand(_selectAllManufacturerCountry, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                ManufacturerCountry manufacturerCountry = new ManufacturerCountry.Builder().WithId(reader.GetInt32(10)).WithName(reader.GetString(11)).Build();
                manufacturerCountries.Add(manufacturerCountry);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return manufacturerCountries;
        }

        public void Update(ManufacturerCountry obj)
        {
            throw new NotImplementedException();
        }
    }
}
