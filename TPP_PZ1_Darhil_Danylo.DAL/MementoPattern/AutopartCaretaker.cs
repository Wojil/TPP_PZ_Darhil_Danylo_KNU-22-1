using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP_PZ_Darhil_Danylo.DAL.MementoPattern
{
    public class AutopartCaretaker
    {
        public Stack<AutopartMemento> History { get; private set; }
        public AutopartCaretaker()
        {
            History = new Stack<AutopartMemento>();
        }
        public AutopartCaretaker(Stack<AutopartMemento> sam)
        {
            History = sam;
        }

    }
}
