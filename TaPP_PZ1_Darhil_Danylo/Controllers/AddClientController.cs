using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPP_PZ_Darhil_Danylo.DAL.DAO.FactoryMethod;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;

namespace TPP_PZ_Darhil_Danylo.Controllers
{
    public class AddClientController : Controller
    {
        DAOFactory DAOFactory = new DAOFactory();
        private readonly IDAO<Client> ClientDAO;

        public AddClientController()
        {
            ClientDAO = DAOFactory.Create<Client>();
        }
        public ActionResult AddClient()
        {
            return View(new Client.Builder().WithLogin("").WithName(""));
        }
        public ActionResult Create(string login, string password, string name, string surname, string patronymic, string phone, string email, string adress)
        {
            if (adress == null)
                adress = " ";
            Client client = new Client.Builder().WithLogin(login).WithPassword(password).WithName(name).WithSurname(surname).WithPatronymic(patronymic).WithPhone(phone).WithEmail(email).WithAdress(adress).Build();
            ClientDAO.Create(client);
            client = null;
            return View("AddClient", client);
        }

    }
}
