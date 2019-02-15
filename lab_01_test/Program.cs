using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_01_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string hi = "hello";
            Console.WriteLine(hi[0]); // Gets char definied in array

            var object1 = new Object();
            int[] myArray = new int[100];
            
            //literal
            var object2 = new
            {
                name = "hi",
                age = 22,
                dob = "21/09/1968"

            };

            //bytes used for dealing with large files

            byte b = 128; // 1000 0000
            byte bMin = 0;
            byte bMax = 255;

            byte[] buffer = new byte[4000];

            //List requires using.System.Collections.Generics

            //private- this class
            //public - anywhere
            //protected - this class and child
            //internal - within the project




        }
    }
}
