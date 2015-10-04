using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace People
{
    public static class Solutions
    {
        public static void Task7_txt_to_xml_people()
        {
            string outputFileName = "../../output/people.xml";
            var encoding = Encoding.GetEncoding("windows-1251");

            string inputFileName = "../../input/people.txt";

            using (var reader = new StreamReader(inputFileName))
            {
                using (XmlTextWriter writer = new XmlTextWriter(outputFileName, encoding))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = ' ';
                    writer.Indentation = 4;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("people");

                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var currentPersonData = line.Split(';');

                        var name = currentPersonData[0].Trim();
                        var address = currentPersonData[1].Trim();
                        var tel = currentPersonData[2].Trim();

                        XElement person = new XElement("person",
                            new XElement("name", name),
                            new XElement("address", address),
                            new XElement("tel", tel));

                        person.WriteTo(writer);
                    }

                    writer.WriteEndDocument();
                    Console.WriteLine("Writing finished. Converted 'input/people.txt' to 'output/people.xml'");
                }
            }
        }
    }
}
