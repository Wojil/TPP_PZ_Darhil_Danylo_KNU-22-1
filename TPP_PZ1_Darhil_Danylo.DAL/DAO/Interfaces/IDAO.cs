using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP_PZ1_Darhil_Danylo.DAL.DAO.Interfaces
{
    public interface IDAO<T>
    {
        public List<T> GetAll();
        public T Get(int id);
        public void Create(T obj);
        public void Update(T obj);
        public void Delete(int id);
        public List<T> SearchByCriteria(string criteria);
    }
}
