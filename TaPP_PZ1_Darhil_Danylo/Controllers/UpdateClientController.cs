﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace TPP_PZ_Darhil_Danylo.Controllers
{
    public class UpdateClientController : Controller
    {
        ClientDAO ClientDAO = new ClientDAO();
        public ActionResult UpdateClient(int id)
        {
            Client client = ClientDAO.Get(id);
            return View(client);
        }
        public ActionResult Update(int id, string login, string password, string name, string surname, string patronymic, string phone, string email, string adress)
        {
            if (adress == null)
                adress = " ";
            Client client = new Client.Builder().WithId(id).WithLogin(login).WithPassword(password).WithName(name).WithSurname(surname).WithPatronymic(patronymic).WithPhone(phone).WithEmail(email).WithAdress(adress).Build();
            ClientDAO.Update(client);
            client = null;
            return View("UpdateClient", client);
        }
    }
}
