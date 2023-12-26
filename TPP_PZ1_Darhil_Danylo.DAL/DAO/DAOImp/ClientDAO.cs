using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Tsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ_Darhil_Danylo.DAL.ObserverPattern.Classes;
using TPP_PZ_Darhil_Danylo.DAL.ObserverPattern.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ1_Darhil_Danylo.DAL.SQLConnection;

namespace TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp
{
    public class ClientDAO : IDAO<Client>, IObservable
    {
        public List<IObserver> observers;
        private SQLContext _sqlContext;
        private const string _selectAllClientsQuery = "select clientid,login,password,name,surname," +
            "patronymic,phone,email,adress from client";
        private const string _deleteClientQuery = "DELETE FROM client WHERE (`clientid` = @id);";
        private const string _searchClientByCriteriaQuery = "select clientid,login,password,name," +
            "surname,patronymic,phone,email,adress from client where name like @searchcriteria" +
            " or login like @searchcriteria";
        private const string _insertClientQuery = "INSERT INTO `client` (`login`," +
            " `password`, `name`, `surname`, `patronymic`, `phone`, `email`, `adress`) VALUES " +
            "(@login, @password, @name,@surname, @patronymic,@phone, @email, @adress);";
        private const string _selectClientByIdQuery = "select * from client where clientid=@id;";
        private const string _updateClientQuery = "UPDATE `client` SET `login` " +
            "= @login, `password` = @password, `name` = @name, `surname` = @surname, " +
            "`patronymic` = @patronymic, `phone` = @phone, `email` = @email, `adress` = @adress" +
            " WHERE (`clientid` = @id);";
        public ClientDAO()
        {
            _sqlContext = SQLContext.getInstance();
            observers = new List<IObserver>();
            new ConsoleWriterObserver(this);
            new FileWriterObserver(this);
        }
        public void Create(Client obj)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_insertClientQuery, connection);
            command.Parameters.AddWithValue("@login", obj.Login);
            command.Parameters.AddWithValue("@password", obj.Password);
            command.Parameters.AddWithValue("@name", obj.Name);
            command.Parameters.AddWithValue("@surname", obj.Surname);
            command.Parameters.AddWithValue("@patronymic", obj.Patronymic);
            command.Parameters.AddWithValue("@phone", obj.Phone);
            command.Parameters.AddWithValue("@email", obj.Email);
            command.Parameters.AddWithValue("@adress", obj.Adress);
            command.ExecuteNonQuery();
            _sqlContext.CloseConnection();
            NotifyObservers(DateTime.Now.ToString() + " Було створено нового клієнта");
        }

        public void Delete(int id)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_deleteClientQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            _sqlContext.CloseConnection();
            NotifyObservers(DateTime.Now.ToString() + " Було видалено клієнта з номером "+id);
        }

        public Client Get(int id)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_selectClientByIdQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            reader.Read();
                Client client = new Client.Builder()
                    .WithId(reader.GetInt32(0))
                    .WithLogin(reader.GetString(1))
                    .WithPassword(reader.GetString(2))
                    .WithName(reader.GetString(3))
                    .WithSurname(reader.GetString(4))
                    .WithPatronymic(reader.GetString(5))
                    .WithPhone(reader.GetString(6))
                    .WithEmail(reader.GetString(7))
                    .WithAdress(reader.GetString(8)).Build();
            reader.Close();
            _sqlContext.CloseConnection();
            return client;
        }

        public List<Client> GetAll()
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_selectAllClientsQuery, connection);
            var reader = command.ExecuteReader();
            List<Client> clients = new List<Client>();
            while (reader.Read())
            {
                Client client = new Client.Builder()
                    .WithId(reader.GetInt32(0))
                    .WithLogin(reader.GetString(1))
                    .WithPassword(reader.GetString(2))
                    .WithName(reader.GetString(3))
                    .WithSurname(reader.GetString(4))
                    .WithPatronymic(reader.GetString(5))
                    .WithPhone(reader.GetString(6))
                    .WithEmail(reader.GetString(7))
                    .WithAdress(reader.GetString(8)).Build();
                clients.Add(client);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return clients;
        }

        public List<Client> SearchByCriteria(string criteria)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_searchClientByCriteriaQuery, connection);
            command.Parameters.AddWithValue("@searchcriteria", "%" + criteria + "%");
            var reader = command.ExecuteReader();
            List<Client> clients = new List<Client>();
            while (reader.Read())
            {
                Client client = new Client.Builder()
                    .WithId(reader.GetInt32(0))
                    .WithLogin(reader.GetString(1))
                    .WithPassword(reader.GetString(2))
                    .WithName(reader.GetString(3))
                    .WithSurname(reader.GetString(4))
                    .WithPatronymic(reader.GetString(5))
                    .WithPhone(reader.GetString(6))
                    .WithEmail(reader.GetString(7))
                    .WithAdress(reader.GetString(8)).Build();
                clients.Add(client);
            }
            reader.Close();
            _sqlContext.CloseConnection();
            return clients;
        }

        public void Update(Client obj)
        {
            var connection = _sqlContext.GetConnection();
            var command = new MySqlCommand(_updateClientQuery, connection);
            command.Parameters.AddWithValue("@id", obj.Id);
            command.Parameters.AddWithValue("@login", obj.Login);
            command.Parameters.AddWithValue("@password", obj.Password);
            command.Parameters.AddWithValue("@name", obj.Name);
            command.Parameters.AddWithValue("@surname", obj.Surname);
            command.Parameters.AddWithValue("@patronymic", obj.Patronymic);
            command.Parameters.AddWithValue("@phone", obj.Phone);
            command.Parameters.AddWithValue("@email", obj.Email);
            command.Parameters.AddWithValue("@adress", obj.Adress);
            command.ExecuteNonQuery();
            _sqlContext.CloseConnection();
            NotifyObservers(DateTime.Now.ToString() + " Було змінено клієнта з номером " + obj.Id);

        }

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers(string message)
        {
            foreach (IObserver o in observers)
            {
                o.Update(message);
            }
        }
    }
}
