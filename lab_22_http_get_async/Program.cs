using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace lab_22_http_get_async
{
    class Program
    {
        static void Main(string[] args)
        {
            //sync read of http data

            Uri bbc01 = new Uri("http://www.bbc.co.uk");
            Uri bbc02 = new Uri("https://www.bbc.co.uk");

            Console.WriteLine(bbc01.Host);
            Console.WriteLine(bbc01.Port);

            Console.WriteLine(bbc02.Host);
            Console.WriteLine(bbc02.Port);

            //Simplest way to read data is with 'web client'

            var bbcWebClient = new WebClient {Proxy = null };
            bbcWebClient.DownloadFile(bbc01,"local-copy-of-bbc01.html");
            Console.WriteLine(File.ReadAllText("local-copy-of-bbc01.html"));
        }
    }
}
