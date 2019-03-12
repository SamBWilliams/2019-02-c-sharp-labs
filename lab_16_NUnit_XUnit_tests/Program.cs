using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_16_NUnit_XUnit_tests
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class TestMeNow
    {
        public double TestThisMethodWorks(double x, double y, double p)
        {
            //2,3,3 => (2*3)=6 to the power of 3, ie 36*6 = 216
            Console.WriteLine($"Here is some data {x} {y} {p}");
            return Math.Pow((x*y),p);
        }
    }
}
