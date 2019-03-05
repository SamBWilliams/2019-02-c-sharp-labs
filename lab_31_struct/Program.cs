using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_31_struct
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point(10, 10);
            var p2 = new Point(20, 20);
        }
    }

    class X { }

    //Structs cannot inherit other structs
    struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
