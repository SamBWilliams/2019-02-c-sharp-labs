using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_33_trivial_event
{
    class Program
    {
        public delegate void MyActionDelegate();
        public static event MyActionDelegate MyEvent;

        static void Main(string[] args)
        {
            MyEvent += MyMethod01;
            MyEvent += MyMethod02;

            MyEvent();
                    
        }

        static void MyMethod01()
        {
            Console.WriteLine("In 01");
        }
        static void MyMethod02()
        {
            Console.WriteLine("In 02");
        }
    }
}
