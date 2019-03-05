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
            Console.WriteLine("r) for Random characters\no) for ordered characters\n");

            char userInput = Console.ReadKey().KeyChar;

            
            switch (userInput)
            {

                case 'r':
                    Console.WriteLine("\nYou have chosen random");
                    Console.WriteLine("\nEnter how many seconds you wish to play for");
                    int timeInputR = Convert.ToInt32(Console.ReadLine());
                    gameRandom(timeInputR);
                    break;

                case 'o':
                    Console.WriteLine("\nYou have chosen ordered");
                    Console.WriteLine("\nEnter how many seconds you wish to play for");
                    int timeInputO = Convert.ToInt32(Console.ReadLine());
                    gameOrdered(timeInputO);
                    break;

                default:
                    Console.WriteLine("Incorrect input");
                    break;
            }

            
        }

        public static void gameRandom(int time)
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
    



        public static void gameOrdered(int time)
        {
            List<char> inputList = new List<char>()
            {'a', 'b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

            Queue<char> orderedInputs = new Queue<char>();

            for (int i =0; i < inputList.Count(); i++)
            {
                orderedInputs.Enqueue(inputList[i]);
            }

            //Testing queue is filled
           // Console.WriteLine(orderedInputs.Count().ToString());

            char input;
            int score = 0;
            Stopwatch timer = new Stopwatch();
            timer.Start();

            while (timer.Elapsed.TotalSeconds < time)
            {
                input = Console.ReadKey().KeyChar;

                if (input == orderedInputs.ElementAt(0))
                {
                    orderedInputs.Dequeue();
                    orderedInputs.Enqueue(input);
                    score++;
                }
                else
                {
                    Console.WriteLine("\nincorrect!\n");
                }
            }
            Console.WriteLine("\n\n Times up\n\n");
            Console.WriteLine($"You entered {score} characters in {time} seconds!");
        }
    }
}
