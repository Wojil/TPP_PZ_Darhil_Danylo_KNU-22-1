using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ_Darhil_Danylo.DAL.ObserverPattern.Interfaces;

namespace TPP_PZ_Darhil_Danylo.DAL.ObserverPattern.Classes
{
    public class ConsoleWriterObserver : IObserver
    {
        public IObservable observerable;
        public ConsoleWriterObserver(IObservable obs)
        {
            observerable = obs;
            obs.AddObserver(this);
        }
        public void Update(string message)
        {
            Console.WriteLine(message);
        }
    }

    /*public class ConsoleObservable<T> : Interfaces.IObservable<T>
{
    public Action<T> OnModelCreated;
    public void NotifyObservers(T obj)
    {
        OnModelCreated?.Invoke(obj);
    }
}*/

}
