using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_02
{
    class Program
    {
        //OOP
        static void Main(string[] args)
        {
            var p01 = new Parent(); //syntactic sugar
            Parent p02 = new Parent(); //regular code

            p01.Age = 10;

            dynamic x = 10; //Version of JS var
            Console.WriteLine(x+1);

            dynamic y = "Hello";
            Console.WriteLine(y+1);
        }

        class Parent
        {
            //field
            private int x;

            //property
            private string Y { get; set; } // Shorthand

            private string ReadMeOnly { get; }

            private int age;
            public int Age
            {
                get
                {
                    return this.age;
                }
                set
                {
                    if (value > 0)
                    {
                        this.age = value;
                    }
                    
                }
            }

            //method

        }

        class Child : Parent
        {

        }
    }
}
