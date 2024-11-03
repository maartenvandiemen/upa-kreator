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

            if (args.Length < 6)
            {
                Console.WriteLine("Please provide all required parameters: sofinr, voorl, voorv, surname, gebdat, aantalVerloondeUren");
                return;
            }

            string sofinr = args[0];
            string voorl = args[1];
            string voorv = args[2];
            string surname = args[3];
            string gebdat = args[4];
            string aantalVerloondeUren = args[5];

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

            XElement sofiNrElement = xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "SofiNr");
            if (sofiNrElement != null)
            {
                sofiNrElement.Value = sofinr;
            }

            XElement voorlElement = xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "Voorl");
            if (voorlElement != null)
            {
                voorlElement.Value = voorl;
            }

            XElement voorvElement = xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "Voorv");
            if (voorvElement != null)
            {
                voorvElement.Value = voorv;
            }

            XElement signNmElement = xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "SignNm");
            if (signNmElement != null)
            {
                signNmElement.Value = surname;
            }

            XElement gebdatElement = xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "Gebdat");
            if (gebdatElement != null)
            {
                gebdatElement.Value = gebdat;
            }

            XElement aantVerlUPensElement = xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "AantVerlUPens");
            if (aantVerlUPensElement != null)
            {
                aantVerlUPensElement.Value = aantalVerloondeUren;
            }

            xmlDoc.Save(outputFilePath);

            Console.WriteLine("Modified XML file has been saved as " + outputFilePath);
        }
    }
}
