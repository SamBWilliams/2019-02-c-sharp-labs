using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_104_array_list_queue_stack_dict_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Put 10 numbers in array
            //Move items to list and add 1 to each item
            //Move to stack and add 1
            //Move to a queue and add 1
            //Move to dictionary and add 1
            //Return total

            List<int> numberList = new List<int>();
            Stack<int> numberStack = new Stack<int>();
            Queue<int> numberQueue = new Queue<int>();
            Dictionary<int, int> numberDict = new Dictionary<int, int>();

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            Console.WriteLine("Original array");
            for (int i = 0; i < numbers.Length; i++)
            {
                
                Console.WriteLine(i);
            }
            Console.WriteLine("List numbers");
            foreach (int num in numbers)
            {

                numberList.Add(num + 1);
                Console.WriteLine(num +1);


            }
            Console.WriteLine("Stack numbers");
            foreach (int num in numberList)
            {
                numberStack.Push(num + 1);
                Console.WriteLine(num + 1);
            }
            Console.WriteLine("Queue numbers");
            for (int i = 0; i < 10; i++)
            {
                numberQueue.Enqueue(numberStack.Pop() + 1);
                Console.WriteLine(i);
            }
            Console.WriteLine("-----------------------\n");
            for (int i = 0; i < 10; i++)
            {
                
                numberDict.Add(i,numberQueue.Dequeue()+1);
                Console.WriteLine(i);

            }

            int total = 0;
            foreach(int key in numberDict.Keys)
            {
                total += numberDict[key];
            }
            Console.WriteLine(total);
            
        }
    }
}
