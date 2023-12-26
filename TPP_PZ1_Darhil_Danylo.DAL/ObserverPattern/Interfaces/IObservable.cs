using Microsoft.SqlServer.Management.Smo.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP_PZ_Darhil_Danylo.DAL.ObserverPattern.Interfaces
{
    /*public interface IObservable<T>
    {
        void NotifyObservers(T obj);
    }*/
    public interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers(string message);
    }
}
