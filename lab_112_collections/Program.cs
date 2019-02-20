using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_112_collections
{
    class Program
    {
        static void Main(string[] args)
        {
        }


    }



    public class Collections
    {

        /*
         * Recieve 3 numbers
         * 
         * Put these numbers into array
         * 
         * Output numbers, double each one and store in stack
         * 
         * Repeat ie Output numbers, double and store in Queue
         * 
         * Output numbers, Square them, then store in List<int>
         * 
         * Add up numbers in the list<int> return total
         */

        public int col20minLab(int n1, int n2, int n3)
        {
            int[] numbers = { n1, n2, n3 };
            Stack<int> numberStack = new Stack<int>();
            Queue<int> numberQueue = new Queue<int>();
            List<int> numberList = new List<int>();

            foreach (int num in numbers)
            {
                numberStack.Push(num * 2);
            }

            //foreach (int num in numberStack)
            //{
            //    numberQueue.Enqueue(numberStack.Pop() * 2);
            //}

            for(int i =0; i < numberStack.Count(); i++)
            {
                numberQueue.Enqueue(numberStack.Pop() * 2);
            }

            //foreach (int num in numberQueue)
            //{
            //    numberList.Add(numberQueue.Dequeue() * num);
            //}

            for (int i =0; i < numberQueue.Count(); i++)
            {
                numberList.Add(numberQueue.Dequeue() * i);
            }

            int total = 0;
            foreach (int i in numberList)
            {
                total += i;
            }

            //int total = numberList[0] + numberList[1] + numberList[2];
            //Console.WriteLine(total);
            return total ;

        }
    }
}


