using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP_PZ1_Darhil_Danylo.DAL.SQLConnection
{
    public class SQLContext
    {
        private static readonly string SQL_CONNECTION = "server=localhost; port=3306; database=tpp_pz_darhil; user=root; password=12345";
        private MySqlConnection _sqlConnection;
        private static SQLContext _sqlContext;
        private SQLContext()
        {
            _sqlConnection = new MySqlConnection(SQL_CONNECTION);
        }
        public static SQLContext getInstance()
        {
            if (_sqlContext == null)
                _sqlContext = new SQLContext();
            return _sqlContext;
        }
        public MySqlConnection GetConnection()
        {
            _sqlConnection.Open();
            return _sqlConnection;
        }
        public void CloseConnection()
        {
            _sqlConnection.Close();
        }
    }
}