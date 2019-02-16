using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_103_randomPerson_01
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 100; i++)
            {
                personGenerator();
            }


        }

        public static void personGenerator()
        {
            string[] names = { "Andrew", "Bethany", "Charlie", "Daniel", "Ellie", "Fred", "Gary", "Helen", "Ian", "Jess" };

            Random rand = new Random();

            int randName = rand.Next(names.Length);
            int randAge = rand.Next(1, 100);

            var person = new Parent();
            Console.WriteLine($"Name: {person.Name = names[randName]} " + $"\nAge: {randAge} " + $"\nDate of birth: {DateTime.Now.AddYears(-randAge)}");
        }

        class Parent
        {
            private string name;
            private int age;
            private DateTime dob;

            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime Dob { get; set; }

            public Parent() { }

            public Parent(string name)
            {
                this.Name = name;
            }

            public Parent(string name, int age, DateTime date)
            {
                this.Name = name;
                this.Age = age;
                this.Dob = dob;
            }
        }
    }
}
