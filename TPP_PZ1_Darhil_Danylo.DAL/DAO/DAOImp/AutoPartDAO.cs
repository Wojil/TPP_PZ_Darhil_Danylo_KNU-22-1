using TPP_PZ1_Darhil_Danylo.DAL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.SQLConnection;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.Reflection.PortableExecutable;

namespace TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp
{
    public class AutoPartDAO : IDAO<AutoPart>
    {
        private SQLContext _sqlContext;
        private const string _selectAllAutoPartsQuery = "select a.autopartid,a.code, m.automodelid, m.automodelname,c.categoryid,c.categoryname,t.typeid,t.typename,b.brandid,b.brandname,mc.countryid,mc.countryname," +
                        "a.partname,a.price,a.partdescription,a.quantity " +
                        "from autoparts a " +
                        "join partcategory c on a.categoryid = c.categoryid " +
                        "join parttype t on t.typeid = a.typeid " +
                        "join automodel m on a.automodelid = m.automodelid " +
                        "join manufacturerbrand b on b.brandid = a.brandid " +
                        "join manufacturercountry mc on mc.countryid = a.countryid; ";
        private const string _selectAutopartByIdQuery = "select a.autopartid,a.code, m.automodelid, m.automodelname,c.categoryid,c.categoryname,t.typeid,t.typename,b.brandid,b.brandname,mc.countryid,mc.countryname," +
                        "a.partname,a.price,a.partdescription,a.quantity " +
                        "from autoparts a " +
                        "join partcategory c on a.categoryid = c.categoryid " +
                        "join parttype t on t.typeid = a.typeid " +
                        "join automodel m on a.automodelid = m.automodelid " +
                        "join manufacturerbrand b on b.brandid = a.brandid " +
                        "join manufacturercountry mc on mc.countryid = a.countryid where a.autopartid = @id; ";
        private const string _deletePartQuery = "DELETE FROM autoparts WHERE (`autopartid` = @id);";
        private const string _searchAutoPartByCodeOrName = "select a.autopartid,a.code, m.automodelid, m.automodelname,c.categoryid,c.categoryname,t.typeid,t.typename,b.brandid,b.brandname,mc.countryid,mc.countryname," +
                         "a.partname,a.price,a.partdescription,a.quantity " +
                         "from autoparts a " +
                         "join partcategory c on a.categoryid = c.categoryid " +
                         "join parttype t on t.typeid = a.typeid " +
                         "join automodel m on a.automodelid = m.automodelid " +
                         "join manufacturerbrand b on b.brandid = a.brandid " +
                         "join manufacturercountry mc on mc.countryid = a.countryid" +
                         " where a.partname like @searchcriteria or a.code like @searchcriteria;";
        private const string _updatePartQuery = "UPDATE autoparts SET `code` =@code," +
    "`automodelid` = (select automodelid from automodel where automodelname=@automodel)," +
    " `categoryid` =(select categoryid from partcategory where categoryname=@partcategory)," +
    " `typeid` =(select typeid from parttype where typename=@parttype)," +
    " `brandid` = (select brandid from manufacturerbrand where brandname = @brand ), " +
    " `countryid` = (select countryid from manufacturercountry where countryname=@country)," +
    " `partname` = @name, `price` =@price,`partdescription` = @description,`quantity` = @quantity " +
    " WHERE `autopartid` = @id;";
        private const string _createPartQuery = "INSERT INTO autoparts (`code`, `automodelid`, `categoryid`, `typeid`, `brandid`, `countryid`, " +
        "`partname`, `price`, `partdescription`, `quantity`) " +
    "VALUES (@code, (select automodelid from automodel where automodelname=@automodel)," +
    " (select categoryid from partcategory where categoryname=@partcategory)," +
    " (select typeid from parttype where typename=@parttype)," +
    " (select brandid from manufacturerbrand where brandname=@brand)," +
    " (select countryid from manufacturercountry where countryname=@country)," +
    " @name, @price, @description, @quantity);";


        public AutoPartDAO()
        {
            _sqlContext = SQLContext.getInstance();
        }

        public void Create(AutoPart obj)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_createPartQuery, connection);
            command.Parameters.AddWithValue("@name", obj.Name);
            command.Parameters.AddWithValue("@code", obj.Code);
            command.Parameters.AddWithValue("@automodel", obj.AutoModel.AutoModelName);
            command.Parameters.AddWithValue("@parttype", obj.PartType.TypeName);
            command.Parameters.AddWithValue("@partcategory", obj.PartCategory.CategoryName);
            command.Parameters.AddWithValue("@brand", obj.ManufacturerBrand.BrandName);
            command.Parameters.AddWithValue("@country", obj.ManufacturerCountry.CountryName);
            command.Parameters.AddWithValue("@description", obj.Description);
            command.Parameters.AddWithValue("@price", obj.Price);
            command.Parameters.AddWithValue("@quantity", obj.Quantity);
            command.ExecuteNonQuery();
            _sqlContext.CloseConnection();
        }

        public void Delete(int id)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_deletePartQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            _sqlContext.CloseConnection();
        }

        public AutoPart Get(int id)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_selectAutopartByIdQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            AutoPart autopart = null;
            while (reader.Read())
            {
                autopart = new AutoPart.Builder()
                    .WithId(reader.GetInt32(0))
                    .WithCode(reader.GetString(1))
                    .WithAutomodel(reader.GetInt32(2), reader.GetString(3))
                    .WithPartCategory(reader.GetInt32(4), reader.GetString(5))
                    .WithPartType(reader.GetInt32(6), reader.GetString(7))
                    .WithManufacturerBrand(reader.GetInt32(8), reader.GetString(9))
                    .WithManufacturerCountry(reader.GetInt32(10), reader.GetString(11))
                    .WithName(reader.GetString(12))
                    .WithPrice(reader.GetDecimal(13))
                    .WithDescription(reader.GetString(14))
                    .WithQuantity(reader.GetInt32(15)).Build();
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return autopart;
        }
        public List<AutoPart> SearchAutoPart(string searchcriteria)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_searchAutoPartByCodeOrName, connection);
            command.Parameters.AddWithValue("@searchcriteria","%"+ searchcriteria+"%");
            var reader = command.ExecuteReader();
            List<AutoPart> autoparts = new List<AutoPart>();
            while (reader.Read())
            {
                AutoPart autopart = new AutoPart.Builder()
                    .WithId(reader.GetInt32(0))
                    .WithCode(reader.GetString(1))
                    .WithAutomodel(reader.GetInt32(2), reader.GetString(3))
                    .WithPartCategory(reader.GetInt32(4), reader.GetString(5))
                    .WithPartType(reader.GetInt32(6), reader.GetString(7))
                    .WithManufacturerBrand(reader.GetInt32(6), reader.GetString(7))
                    .WithManufacturerCountry(reader.GetInt32(10), reader.GetString(11))
                    .WithName(reader.GetString(12))
                    .WithPrice(reader.GetDecimal(13))
                    .WithDescription(reader.GetString(14))
                    .WithQuantity(reader.GetInt32(15)).Build();
                autoparts.Add(autopart);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return autoparts;
        }
        public List<AutoPart> GetAll()
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_selectAllAutoPartsQuery, connection);
            var reader = command.ExecuteReader();
            List<AutoPart> autoparts = new List<AutoPart>();
            while (reader.Read())
            {
                AutoPart autopart = new AutoPart.Builder()
                    .WithId(reader.GetInt32(0))
                    .WithCode(reader.GetString(1))
                    .WithAutomodel(reader.GetInt32(2), reader.GetString(3))
                    .WithPartCategory(reader.GetInt32(4), reader.GetString(5))
                    .WithPartType(reader.GetInt32(6), reader.GetString(7))
                    .WithManufacturerBrand(reader.GetInt32(6), reader.GetString(7))
                    .WithManufacturerCountry(reader.GetInt32(10), reader.GetString(11))
                    .WithName(reader.GetString(12))
                    .WithPrice(reader.GetDecimal(13))
                    .WithDescription(reader.GetString(14))
                    .WithQuantity(reader.GetInt32(15)).Build();
                autoparts.Add(autopart);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return autoparts;
        }
        public void Update(AutoPart obj)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_updatePartQuery, connection);
            command.Parameters.AddWithValue("@id",obj.Id);
            command.Parameters.AddWithValue("@name", obj.Name);
            command.Parameters.AddWithValue("@code", obj.Code);
            command.Parameters.AddWithValue("@automodel", obj.AutoModel.AutoModelName);
            command.Parameters.AddWithValue("@parttype", obj.PartType.TypeName);
            command.Parameters.AddWithValue("@partcategory", obj.PartCategory.CategoryName);
            command.Parameters.AddWithValue("@brand", obj.ManufacturerBrand.BrandName);
            command.Parameters.AddWithValue("@country", obj.ManufacturerCountry.CountryName);
            command.Parameters.AddWithValue("@description", obj.Description);
            command.Parameters.AddWithValue("@price", obj.Price);
            command.Parameters.AddWithValue("@quantity", obj.Quantity);
            command.ExecuteNonQuery();
            _sqlContext.CloseConnection();
        }
    }
}
