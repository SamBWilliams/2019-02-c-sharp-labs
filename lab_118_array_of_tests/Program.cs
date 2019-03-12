using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace lab_118_array_of_tests
{
    class Program
    {
        static void Main(string[] args)
        {

            FileOperationSynchro fos = new FileOperationSynchro();
            //fos.FileReadWrite(1000);

            //fos.CreateFiles(1000);

            fos.TaskArrayFileReadWrite(1000);
            //string data = "Saving some data";
            ////create stopwatch
            //var s = new Stopwatch();
            //s.Start();
            ////write 1000 times to a file synchronously
            //for (int i = 0; i < 1000; i++)
            //{
            //    File.WriteAllText("data.txt", data + i);
            //}

            ////read 1000 time that same file
            //for (int i = 0; i < 1000; i++)
            //{
            //    File.ReadAllText("data.txt");
            //}
            ////end stopwatch
            //s.Stop();
            //Console.WriteLine($"Total time 1000 files write then read is {s.ElapsedMilliseconds}");


            //upgrade to this : create 1000 files - name them by adding number to string
            //string filename = "data" + string.format(i,D3) + ".txt";
            //  data000.txt data999.txt
        }
    }

    public class FileOperationSynchro
    {
        public long FileReadWrite(int numberOfFiles)
        {

            string data = "Saving some data - ";
            //create stopwatch
            var s = new Stopwatch();
            s.Start();
            //write 1000 times to a file synchronously
            for (int i = 0; i < numberOfFiles; i++)
            {
                File.WriteAllText("data.txt", data + i);
            }

            //read 1000 time that same file
            for (int i = 0; i < numberOfFiles; i++)
            {
                File.ReadAllText("data.txt");
            }


            //end stopwatch
            s.Stop();
            string output = "Total time 1000 files write then read is "+ $"{s.ElapsedMilliseconds}";
            //Console.WriteLine(output);

            return s.ElapsedMilliseconds;
        }

        public long TaskArrayFileReadWrite(int numberOfFiles)
        {
            //one task (input) => {method body}
            var singleTask = Task.Run(()=> { }   );

            Task.WaitAll(singleTask);

            var s = new Stopwatch();
            s.Start();

            //array of task
            Task[] tasks = new Task[numberOfFiles];

            for(int i=0; i < numberOfFiles; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    //write to file
                    CreateFiles(numberOfFiles);

                    //read from file
                    ReadFiles(numberOfFiles);
                });
            }

            Task.WaitAll(tasks);
            s.Stop();

            return s.ElapsedMilliseconds;

            //HW: 1) complete and test read/write 1000 then 10000 files as task
            //    2) Bonus: create new project. add northwind. update contact
            //              name of 1 customer 1000 times using 1000 tasks
        }


        public void CreateFiles(int noOfFiles)
        {
            
            for (int i = 0; i < noOfFiles; i++)
            {
                string filename = "Data" + string.Format("{0:000}", i) + ".txt";
                File.Create(filename);
            }
        }

        public void ReadFiles(int noOfFiles)
        {
            for (int i = 0; i < noOfFiles; i++)
            {
                string filename = "Data" + string.Format("{0:000}", i) + ".txt";
                File.ReadAllText(filename);
            }
        }

        //Parallel.Foreach(array, count to x) - Executes tasks async
    }
}
