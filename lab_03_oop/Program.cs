using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            var p01 = new Parent("Bill", 44);
            var p02 = new Parent(age: 22, name: "Bill");
            p01.Name = "Bill";
        }
        class Parent
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Parent() { } // Default constructor
            public Parent(string name)
            {
                this.Name = name;
            }
            public Parent(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }


        }
    }
}
