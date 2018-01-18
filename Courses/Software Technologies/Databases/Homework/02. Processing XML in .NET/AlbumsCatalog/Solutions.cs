using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace AlbumsCatalog
{
    public static class Solutions
    {
        public static void Task1_2_extract_artists()
        {
            var inputFileName = "../../input/catalog.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(inputFileName);
            XmlNode rootNode = doc.DocumentElement;
            var albumsCount = new Hashtable();

            foreach (XmlNode node in rootNode)
            {
                foreach (XmlNode childNode in node)
                {
                    if (childNode.Name == "artist")
                    {
                        var artistName = childNode.InnerText;
                        var currentCount = albumsCount[artistName];

                        if (currentCount != null)
                        {
                            albumsCount[artistName] = (int)(currentCount) + 1;
                        }
                        else
                        {
                            albumsCount[artistName] = 1;
                        }
                    }
                }
            }

            var artistKeys = albumsCount.Keys;

            foreach (var artistKey in artistKeys)
            {
                Console.WriteLine("{0} : {1} albums", artistKey, albumsCount[artistKey]);
            }
        }

        public static void Task3_extract_artists_XPath()
        {
            var inputFileName = "../../input/catalog.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(inputFileName);
            var artistNodes = doc.SelectNodes("//artist");
            var albumsCount = new Hashtable();

            foreach (XmlNode artistNode in artistNodes)
            {
                var artistName = artistNode.InnerText;
                var currentAlbumsCount = albumsCount[artistName];

                if (currentAlbumsCount != null)
                {
                    albumsCount[artistName] = (int)currentAlbumsCount + 1;
                }
                else
                {
                    albumsCount[artistName] = 1;
                }
            }

            var artistKeys = albumsCount.Keys;

            foreach (var artistKey in artistKeys)
            {
                Console.WriteLine("{0} : {1} albums", artistKey, albumsCount[artistKey]);
            }
        }

        public static void Task4_delete_expensive_albums()
        {
            var inputFileName = "../../input/catalog.xml";
            var outputFileName = "../../output/catalog_cheap_albums.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(inputFileName);
            var rootNode = doc.DocumentElement;
            var nodesToRemove = new List<XmlNode>();

            // IMPORTANT! We need two foreach cycles, because we break the iteration logic
            // if we traverse and remove child elements from the root at the same time
            // First we collect references to nodes fore removal,
            // then the references collection is iterated and each of the references
            // removed from the rootNode reference.
            foreach (XmlNode node in rootNode)
            {
                if (Int32.Parse(node["price"].InnerText) >= 20)
                {
                    nodesToRemove.Add(node);
                }
            }

            foreach (XmlNode node in nodesToRemove)
            {
                rootNode.RemoveChild(node);
            }

            doc.Save(outputFileName);
            Console.WriteLine("Result saved to {0}", outputFileName);
        }

        /// <summary>
        /// Good for large files.
        /// </summary>
        public static void Task5_extract_song_titles()
        {
            var inputFileName = "../../input/catalog.xml";
            var songTitles = new List<string>();

            using (XmlReader reader = XmlReader.Create(inputFileName))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        var title = reader.ReadInnerXml();
                        if (!songTitles.Contains(title))
                        {
                            songTitles.Add(title);
                        }
                    }
                }
            }

            foreach (var title in songTitles)
            {
                Console.WriteLine(title);
            }
        }

        /// <summary>
        /// Not efficient for large files.
        /// </summary>
        public static void Task6_extract_song_titles_LINQ()
        {
            var inputFileName = "../../input/catalog.xml";
            XDocument xmlDoc = XDocument.Load(inputFileName);

            var songs =
                from title in xmlDoc.Descendants("title")
                select title.Value;

            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }

        public static void Task8_catalog_to_album_xml()
        {
            var inputFileName = "../../input/catalog.xml";

            string outputFileName = "../../output/album.xml";
            var encoding = Encoding.GetEncoding("windows-1251");

            using (XmlReader reader = XmlReader.Create(inputFileName))
            {
                using (XmlTextWriter writer = new XmlTextWriter(outputFileName, encoding))
                {
                    XElement person = new XElement("dummy");

                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = ' ';
                    writer.Indentation = 4;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");

                    while (reader.Read())
                    {
                        var nodeName = reader.Name;
                        string nodeValue;

                        switch (nodeName)
                        {
                            case "name":
                                nodeValue = reader.ReadElementString();
                                person = new XElement("album",
                                    new XElement("name", nodeValue));
                                break;
                            case "artist":
                                nodeValue = reader.ReadElementString();
                                person.Add(new XElement("artist", nodeValue));
                                person.WriteTo(writer);
                                break;
                            default:
                                break;
                        }
                    }

                    writer.WriteEndDocument();
                    Console.WriteLine("Writing finished to 'album.xml'");

                }
            }
        }

        public static void Task11_extract_older_published_albums()
        {
            var inputFileName = "../../input/catalog.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(inputFileName);

            var currentYear = DateTime.Now.Year;
            var queryString = String.Format("//album[year<={0}]/price", currentYear - 5);

            var priceNodes = doc.SelectNodes(queryString);
            foreach (XmlNode priceNode in priceNodes)
            {
                Console.WriteLine(priceNode.InnerText);
            }
        }

        public static void Task12_13_extract_older_published_albums_LINQ()
        {
            var inputFileName = "../../input/catalog.xml";
            XDocument xmlDoc = XDocument.Load(inputFileName);
            var currentYear = DateTime.Now.Year;

            var prices =
                from album in xmlDoc.Descendants("album")
                where Int32.Parse(album.Element("year").Value) <= currentYear - 5
                select album.Element("price").Value;

            foreach (var price in prices)
            {
                Console.WriteLine(price);
            }
        }

        public static void Task14_xsl_to_xhtml()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../input/catalog-style.xslt");
            xslt.Transform("../../input/catalog.xml", "../../output/catalog.html");

            Console.WriteLine("/input/catalog.xml converted to output/catalog.html");
        }

        public static void Task16_schema_validation_with_cSharp()
        {
            var validFilePath = "../../input/catalog.xml";
            var invalidFilePath = "../../input/invalid-catalog.xml";
            var schemaFilePath = "../../input/catalog-schema.xsd";

            XmlDocument doc = new XmlDocument();
            doc.Schemas.Add(null, schemaFilePath);
            ValidationEventHandler handler = new ValidationEventHandler(ValidationEventHandler);

            Console.WriteLine("Validating valid xml. {0}", validFilePath);
            doc.Load(validFilePath);
            doc.Validate(handler);
            Console.WriteLine("done!");

            Console.WriteLine("Validating invalid xml. {0}", invalidFilePath);
            doc.Load(invalidFilePath);
            doc.Validate(handler);
            Console.WriteLine("done!");
        }

        public static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }
        }
    }
}
