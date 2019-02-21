using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_13_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Parent {

        //Regular method
        public virtual void doThis() { }

        public void doThat() { }


    }

    class Child : Parent {

        public override void doThis()
        {
            
        }

    }
}
