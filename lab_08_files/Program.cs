using System;
using System.IO;
using System.Text;

namespace lab_08_files
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read file
            string data01 = File.ReadAllText("file.txt");
            Console.WriteLine(data01);
            //Add encoding (optional)
            string data02 = File.ReadAllText("File.txt", Encoding.UTF8);
            Console.WriteLine($"\n\n\n{data02}");
            //Environment.NewLine; - Same as \n

            Console.WriteLine($"\n\n\n{"hi", -30}{"there", -20}");
            Console.WriteLine($"\n\n\n{"how", -30}{"are", -20}");
            Console.WriteLine($"\n\n\n{"you", -30}{"????", -20}");

            //read as array
            string[] data03 = File.ReadAllLines("file.txt");
            Console.WriteLine(data03[0]);
            //Console.WriteLine(data03[1]); - If there are multiple lines would choose 2nd line

            //write data
            Console.WriteLine("\ncreate new file\n");
            File.WriteAllText("file2.txt", "here is \n some \n data");
            Console.WriteLine(File.ReadAllLines("file2.txt"));

            Console.WriteLine("\nNow write an array to text\n");
            File.WriteAllLines("file3.txt", data03);
            Console.WriteLine("\nAnd read it back \n");
            Console.WriteLine(File.ReadAllText("file3.txt"));

            //Copy file
            File.Copy("file.txt", "copyoffile1.txt", true); //overwrite (true)

            //Delete file
            File.Delete("copyoffile1.txt");

            Console.WriteLine("\ndoes my file exist?\n");
            Console.WriteLine(File.Exists("file.txt"));

            Console.WriteLine(File.GetCreationTime("file.txt"));
            Console.WriteLine(File.GetLastWriteTime("file.txt"));

            //Extra info
            var fileinfo = new FileInfo("file.txt");
            Console.WriteLine(fileinfo.DirectoryName);
            Console.WriteLine(fileinfo.Extension);

            //Directory
            Directory.CreateDirectory("folderA");
            Directory.CreateDirectory("folderB");
            Directory.Delete("folderB");
            File.Create("folderA/abc.txt");
            Console.WriteLine("\nlist files in folder");
            var fileArray = Directory.GetFiles("folderA");
            Console.WriteLine(fileArray[0]);
            


        }
    }
}
