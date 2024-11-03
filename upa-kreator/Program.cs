using System;
using System.IO;
using System.Xml.Linq;

namespace UpaKreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string templateFilePath = "template.xml";
            string outputFilePath = "output.xml";

            if (!File.Exists(templateFilePath))
            {
                Console.WriteLine("Template file not found.");
                return;
            }

            XDocument xmlDoc = XDocument.Load(templateFilePath);

            XElement idBerElement = xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "IdBer");
            if (idBerElement != null)
            {
                idBerElement.Value = Guid.NewGuid().ToString();
            }

            XElement datTdAanmElement = xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "DatTdAanm");
            if (datTdAanmElement != null)
            {
                datTdAanmElement.Value = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            }

            xmlDoc.Save(outputFilePath);

            Console.WriteLine("Modified XML file has been saved as " + outputFilePath);
        }
    }
}
