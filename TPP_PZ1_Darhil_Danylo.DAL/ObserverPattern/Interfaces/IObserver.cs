using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP_PZ_Darhil_Danylo.DAL.ObserverPattern.Interfaces
{
    public interface IObserver
    {
        void Update(string message);
    }
}
