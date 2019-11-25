using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        private Queue<string> myString = new Queue<string>();
        private Queue<string> myr = new Queue<string>();
        private Queue<string> my2 = Queue.Synchronized(myr);
    }
}