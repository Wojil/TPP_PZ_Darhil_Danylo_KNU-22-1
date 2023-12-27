using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPP_PZ_Darhil_Danylo.DAL.DAO.FactoryMethod;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace TPP_PZ_Darhil_Danylo.Controllers
{
    public class AuthorizationController : Controller
    {
        DAOFactory DAOFactory = new DAOFactory();
        private readonly ClientDAO ClientDAO;
        public AuthorizationController()
        {
            ClientDAO = new ClientDAO();
        }
        public ActionResult BeginAuthorization()
        {
            return View("Authorization",null);
        }
        public ActionResult SetRole(string login, string password)
        {
            string role;
            role=ClientDAO.CheckClient(login,password);
            if (role == null)
                role = "Ви не були авторизовані, не вірний логін або пароль !";
            else 
            {
                System.IO.File.WriteAllText("UserRole.txt", role);
                role = "Ви успішно авторизувались як " + role; 
            }

            return View("Authorization", role);
        }

    }
}
