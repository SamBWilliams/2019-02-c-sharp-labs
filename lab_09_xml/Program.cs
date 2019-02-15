using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//USE XML
using System.Xml.Linq;

namespace lab_09_xml
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nMost basic XML element\n");

            var xml01 = new XElement("test", 1); // Test= name of field, 1 = value of data
            Console.WriteLine(xml01);

            Console.WriteLine("\nNow add sub element\n");
            var xml02 = new XElement("RootElement",
                new XElement("SubElement", 100));
            Console.WriteLine(xml02);

            Console.WriteLine("\nNow add sub element\n");
            var xml03 = new XElement("RootElement",
                new XElement("SubElement", 100),
                new XElement("SubElement", 100),
                new XElement("SubElement", 100),
                new XElement("SubElement", 100),
                new XElement("SubElement", 100)
                );
            Console.WriteLine(xml03);

            Console.WriteLine("\nNow add sub attributes\n");
            var xml04 = new XElement("RootElement",
                new XElement("SubElement",
                    new XAttribute("height", 500), 100),
                new XElement("SubElement", 100),
                new XElement("SubElement", 100),
                new XElement("SubElement", 100),
                new XElement("SubElement", 100)
                );
            Console.WriteLine(xml04);

            Console.WriteLine("\nNow add attributes on all\n");
            var xml05 = new XElement("RootElement",
                new XElement("SubElement",
                    new XAttribute("height", 500), 100),
                new XElement("SubElement",
                    new XAttribute("height", 500), 100),
                new XElement("SubElement",
                    new XAttribute("height", 500), 100),
                new XElement("SubElement",
                    new XAttribute("height", 500), 100),
                new XElement("SubElement",
                    new XAttribute("height", 500), 100)
                );
            Console.WriteLine(xml05);

            //Save XML to file
            Console.WriteLine("\nNow save to document\n");
            var xml06 = new XElement("RootElement",
                new XElement("SubElement",
                    new XAttribute("height", 500), 100),
                new XElement("SubElement",
                    new XAttribute("height", 500), 100),
                new XElement("SubElement",
                    new XAttribute("height", 500), 100),
                new XElement("SubElement",
                    new XAttribute("height", 500), 100),
                new XElement("SubElement",
                    new XAttribute("height", 500), 100)
                );
            Console.WriteLine(xml06);
            //XDocument : save to file
            var doc06 = new XDocument(XElement.Parse(xml06.ToString()));
            var doc02 = new XDocument(XElement.Parse(xml02.ToString()));
            doc06.Save("Xml06"); //.xml to state type
            doc02.Save("Xml02.xml");

            Console.WriteLine("Read file");

            var displayXml = XDocument.Load("Xml02.xml");           
            Console.WriteLine(displayXml);
            


        }
    }
}
