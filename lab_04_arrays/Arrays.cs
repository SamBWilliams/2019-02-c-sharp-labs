using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04_arrays
{
    public class Arrays
    {
        //build some code here : test output
        //sum squares
        public int CreateArray(int size)
        {
            int[] myArray = new int[size];
            //insert squares
            for(int i=0; i<size; i++)
            {
                myArray[i] = i * i;
            }

            //check values
            int total = 0;
            foreach (int i in myArray)
            {
                total += i;
                //Console.WriteLine(myArray[i]);
                //Console.WriteLine(total);
            }
            return total;
        }


    }
}
