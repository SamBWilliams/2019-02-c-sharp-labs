using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace lab_19_streaming_writer
{
    class Program
    {
        static string line;
        static List<string> list = new List<string>();

        static void Main(string[] args)
        {
            //Main thread

            Console.WriteLine("Program has started");

            ReadData();
            Console.WriteLine("Sleeping finished so starting work now");
            ReadDataAsync();
            Thread.Sleep(30);
            Console.WriteLine("Code has finished");
            Console.ReadLine();

        }

        static void ReadData()
        {
            Thread.Sleep(2000);
        }

        static async void ReadDataAsync()
        {
            using (var reader = new StreamReader("data.txt"))
            {
                while (true)
                {
                    line = await reader.ReadLineAsync();
                    if (line == null)
                    {
                        break;
                    }
                    list.Add(line);
                    Console.WriteLine(line);
                }
            }
            Thread.Sleep(3000);
            Console.WriteLine("Work has finished");
        }
    }
}
