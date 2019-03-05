using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_18_streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            //Not using streaming : writing directly
            //string File01 = File.ReadAllText("test.txt");

            //Stream reading
            //Create stream reader object
            //Enclose it in using block (complete cleanup afterwards)
            //Readline() stream and read line by line

            //path as variable
            string path01 = "data.txt"; //Relative
            //using (var reader = new StreamReader(path01))


            string path02 = "C:/2019-02-c-sharp-labs/lab_18_streaming/bin/Debug/data.txt"; //Absolute
            //using (var reader = new StreamReader(path02))

            string path03 = "C:\\2019-02-c-sharp-labs\\lab_18_streaming\\bin\\Debug\\data.txt"; //Absolute with double backslash 'escape'
            // \t = tab, \n = new line, \' will print single apostrophe

            string path04 = @"C:/2019-02-c-sharp-labs/lab_18_streaming/bin/Debug/data.txt"; //@ means treat following string literally

            //Environment variables : my documents path
            string path05 = Environment.ExpandEnvironmentVariables("%userprofile%")
                + "\\Documents\\data.txt";
            Console.WriteLine(path05);

            string path06 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\data.txt";


            //using (var reader = new StreamReader("data.txt"))
            using (var reader = new StreamReader(path06))
            {
                string output;
                //read every line
                //output to string
                //test each time string is not null
                //continue looping until out of data
                while ((output = reader.ReadLine()) != null)
                {
                    list.Add(output);
                }
            }
            list.ForEach(output => Console.WriteLine(output));


            //Instead of ReadLine(), read() can be used for reading character by character
            //Test for end of data with reader.Peek = -1
            //while (reader.Peek != -1){ //get next character : char c = reader.read()}
            //Peek => look at next item but not remove it
            //Queue, Stack also have this method

            //Reading asynchronously
            //If our read is going to take a while then the code can 'hang'
            //This is because the main 'thread' is doing all the work
            //Asunchronously code creates a new 'thread' leaving the main thread free to continue our code

            //Async methods always have the same pattern.
            //  async .... MethodName(){
                     //await...do task which takes a long time
            //} 

            //Note : one CPU core can still run multiple threads


        }

    }
}
