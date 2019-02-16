using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab_101__speedTyping_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter characters before time is up\n");
            Console.WriteLine("Enter S to start\n");

            char userInput = Console.ReadKey().KeyChar;

            if (userInput == 's' || userInput == 'S')
            {
                Console.WriteLine("\nEnter how many seconds you wish to play for");
                int timeInput = Convert.ToInt32(Console.ReadLine());
                game(timeInput);
            }
        }



        public static void game(int time)
        {
            List<char> inputList = new List<char>();
            char input;
            Stopwatch timer = new Stopwatch();
            timer.Start();

            while (timer.Elapsed.TotalSeconds < time)
            {
                input = Console.ReadKey().KeyChar;
                inputList.Add(input);
            }
            Console.WriteLine("\n\n Times up\n\n");
            Console.WriteLine($"You entered {inputList.Count().ToString()} characters in {time} seconds!");
        }
    }
}
