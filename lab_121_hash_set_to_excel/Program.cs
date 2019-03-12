using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace lab_121_hash_set_to_excel
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSetToExcel hStE = new HashSetToExcel();
            Console.WriteLine(hStE.HasSetExcelTest(10, 20, 30).ToString());

        }
    }

    public class HashSetToExcel
    {
        public Custom HasSetExcelTest(int a, int b, int c)
        {           
            Stopwatch s = new Stopwatch();

            int[] numArray = { a, b, c };
            LinkedList<int> numLinked = new LinkedList<int>();
            HashSet<int> numHash = new HashSet<int>();
            Dictionary<int, int> numDict = new Dictionary<int, int>();
            s.Start();

            foreach (int elem in numArray)
            {
                numLinked.AddLast(elem * 2);
            }

            foreach (int elem in numLinked)
            {
                numHash.Add(elem * 2);
            }

            int i = 0;
            foreach (int elem in numHash)
            {              
                numDict.Add(i, (elem + 15) * 3);
                i++;
            }

            s.Stop();
            double eT = s.ElapsedMilliseconds;
            Custom cust = new Custom(eT, numDict[0], numDict[1], numDict[2]);

            return cust;

        }


    }
    public class Custom
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
