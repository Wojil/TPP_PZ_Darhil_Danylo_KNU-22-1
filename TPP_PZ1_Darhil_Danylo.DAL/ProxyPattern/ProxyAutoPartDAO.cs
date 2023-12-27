using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace TPP_PZ_Darhil_Danylo.DAL.ProxyPattern
{
    internal class ProxyAutoPartDAO : IDAO<AutoPart>
    {
        private UserRolesEnum role;
        private AutoPartDAO autoPartDAO;
        public ProxyAutoPartDAO(UserRolesEnum role)
        {
            this.role = role;
            this.autoPartDAO = new AutoPartDAO();
        }
        public void Create(AutoPart obj)
        {
            if (role == UserRolesEnum.admin)
            {
                autoPartDAO.Create(obj);
            }
            else
            {
                Console.WriteLine("Звичайний користувач не може додати нову автозапчастину, дану дію може виконувати лише адмін !");
            }
        }

        public void Delete(int id)
        {
            if (role == UserRolesEnum.admin)
            {
                autoPartDAO.Delete(id);
            }
            else
            {
                Console.WriteLine("Звичайний користувач не може видаляти автозапчастини, дану дію може виконувати лише адмін !");
            }
        }
        public AutoPart Get(int id)
        {
            return this.autoPartDAO.Get(id);
        }

        public List<AutoPart> GetAll()
        {
            return this.autoPartDAO.GetAll();
        }

        public List<AutoPart> SearchByCriteria(string criteria)
        {
            return this.autoPartDAO.SearchByCriteria(criteria);
        }
        
        public void Update(AutoPart obj)
        {
            if (role == UserRolesEnum.admin)
            {
                autoPartDAO.Update(obj);
            }
            else
            {
                Console.WriteLine("Звичайний користувач не може змінювати дані автозапчастини, дану дію може виконувати лише адмін !");
            }
        }
    }
}
