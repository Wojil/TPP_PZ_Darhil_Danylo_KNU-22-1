using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces;
using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace TPP_PZ_Darhil_Danylo.DAL.DAO.FactoryMethod
{
    public class DAOFactory
    {
        public IDAO<T> Create<T>() where T : class
        {
            object dao;
            var type = typeof(T);
            dao = type switch
            {
                _ when typeof(T) == typeof(AutoModel) => new AutoModelDAO(),
                _ when typeof(T) == typeof(PartCategory) => new PartCategoryDAO(),
                _ when typeof(T) == typeof(PartType) => new PartTypeDAO(),
                _ when typeof(T) == typeof(AutoPart) => new AutoPartDAO(),
                _ when typeof(T) == typeof(Client) => new ClientDAO(),
                _ when typeof(T) == typeof(Manager) => new ManagerDAO(),
                _ when typeof(T) == typeof(ManufacturerBrand) => new ManufacturerBrandDAO(),
                _ when typeof(T) == typeof(ManufacturerCountry) => new ManufacturerCountryDAO(),
                _ when typeof(T) == typeof(Order) => new OrderDAO(),
                _ when typeof(T) == typeof(OrdersAutoParts) => new OrdersAutoPartsDAO(),
                _ when typeof(T) == typeof(OrderStatus) => new OrderStatusDAO(),
            };

            return dao as IDAO<T>;
        }
    }
}
