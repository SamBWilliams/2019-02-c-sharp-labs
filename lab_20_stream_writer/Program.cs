using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_20_stream_writer
{
    class Program
    {
        static void Main(string[] args)
        {
            //overwrite mode

            using (var writer = new StreamWriter("data.txt"))
            {
                for(int i = 0; i < 10000; i++)
                {
                    writer.WriteLine($"Data line: {i}");
                }
            }

            //Append mode
            using (var writer = new StreamWriter("data.txt", true)) //Adds to file
            //using (var writer = new StreamWriter("data.txt", false)) //Overwites file
            {
                writer.WriteLine("and some more");
            }

            //Set encoding (UTF8 default)
            using (var writer = new StreamWriter("data.txt", true,Encoding.UTF8))
            {
                writer.WriteLine("and some more");
            }

            //huge file : can speed up process by altering 'buffer size'
            //which is the unit of data transfer

            using (var writer = new StreamWriter("data.txt",true,Encoding.UTF8, 10000))
            {
                writer.WriteLine("lots and lots and lots of data");
            }
        }
    }
}
