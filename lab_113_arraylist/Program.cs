using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace lab_113_arraylist
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrList = new arrayList();
            arrList.arrayListMethod(10, 20, 30, 40);
        }

    }

    public class arrayList
    {
        public int arrayListMethod(int a, int b, int c, int d)
        {
            //accept 4 integers
            /*
             * put to Array
             * extract => double => put to queue
             * extract => double => put to stack
             * extract => square => put to dictionary
             * put to arraylist
             * extract and get sum of items and return this sum
             */

            int[] arr = { a, b, c, d };
            Queue<int> queue = new Queue<int>();
            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            ArrayList arrList = new ArrayList();
            foreach(int i in arr) //(int i =0; i < arr.Length; i++)
            {
                queue.Enqueue(i * 2);
            }
            for (int i =0; i < arr.Length; i++)
            {
                int dQueued = queue.Dequeue();
                stack.Push(dQueued * 2);
            }
            for (int i =0; i < arr.Length; i++)
            {
                int stackPop = stack.Pop();
                dict.Add(i, stackPop*stackPop);
            }
            //for (int i=0; i < 4; i++)
            //{
            //    myarrayList.Add(dict.Remove
            //}
            foreach(var item in dict)
            {
                arrList.Add(item.Value);

               
            }
            int sum = 0;
            for (int i=0; i < arrList.Capacity; i++)
            {
                
                sum += i;
            }
            


            return sum;

            
        }
    }
}
