using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_14_anotherOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Blueprint b = new Blueprint();

            //Instnatiation
            House h = new House();
            h.Length = 3;
            h.numFloors = 2;
            h.numWindows = 10;

        }
    }

    class Blueprint
    {
        public string field01;
        public int field02;
    }
    //Instructions to build house
    class House
    {
        public int numFloors;
        public int numWindows;
        public double Length { get; set; }
    }
}
