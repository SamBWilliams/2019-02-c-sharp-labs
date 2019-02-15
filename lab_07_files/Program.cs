using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_07_files
{
    class Program
    {
        static void Main(string[] args)
        {
            //Could possibly crash
            try
            {
                //File read as string
                string data01 = File.ReadAllText("file.txt");
            }
            //Specific
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("Make that file");
            }
            //Always run regardless
            finally
            {
                Console.WriteLine("and make it quick");
            }
        }
    }
}
