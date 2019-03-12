using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace lab_121_2nd_attempt
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new HashsetBuilder();
            instance.createCustomObject(10, 20, 30);               
        }
    }

    class HashsetBuilder
    {
        public Custom createCustomObject(int n1, int n2, int n3)
        {
            int[] arr = { n1, n2, n3 };
            LinkedList<int> linked = new LinkedList<int>();
            HashSet<int> hashSet = new HashSet<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            Stopwatch s = new Stopwatch();

            s.Start();

            foreach(int elem in arr)
            {
                linked.AddFirst(elem * 2);
            }
            foreach(int elem in linked)
            {
                hashSet.Add(elem * 2);
            }

            int i = 0;
            foreach(int elem in hashSet)
            {
                dict.Add(i, (elem + 15) * 3);
                i++;
            }

            double eT = s.ElapsedMilliseconds;
            Custom cust = new Custom(eT, dict[0], dict[1], dict[2]);

            Process excel = new Process();
             
            return cust;

            //void times2(Object o, Object o2)
            //{
            //    foreach(int elem in o)
            //    {

            //    }
            //}
            
        }

    }

    class Custom
    {
        public double Etime { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Num3 { get; set; }

        public Custom() { }

        public Custom(double eTime, int num1, int num2, int num3)
        {
            this.Etime = eTime;
            this.Num1 = num1;
            this.Num2 = num2;
            this.Num3 = num3;
        }
    }
}
