using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_21_push_data_to_memory
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var memorystream = new MemoryStream())
            {
                byte[] buffer = new byte[100];
                //memorystream.BeginWrite(buffer);

                memorystream.Flush(); // Send data

                memorystream.Position = 0; // Reset pointer to start

                //read data
                var reader = new StreamReader(memorystream);
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
