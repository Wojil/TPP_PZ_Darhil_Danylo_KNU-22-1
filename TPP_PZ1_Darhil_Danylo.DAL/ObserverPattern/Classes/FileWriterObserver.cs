using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ_Darhil_Danylo.DAL.ObserverPattern.Interfaces;

namespace TPP_PZ_Darhil_Danylo.DAL.ObserverPattern.Classes
{
    public class FileWriterObserver:IObserver
    {
        private string filePath;
        public IObservable observerable;
        public FileWriterObserver(IObservable obs)
        {
            observerable = obs;
            obs.AddObserver(this);
            filePath = "C:\\Users\\wojil\\source\\repos\\TPP_PZ1_Darhil_Danylo\\TaPP_PZ1_Darhil_Danylo\\ObserversMadeFiles\\FileWrittenByObserver " + DateTime.Now.ToString("yyyy_MM_dd");
        }
        public void Update(string message)
        {
            File.AppendAllText(filePath, message + Environment.NewLine);
        }
    }
}
