using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RSSParser
{
    class Program
    {
        static void Main()
        {
            // Not what some might consider High quality code, but for the purpose of easier checking
            // the code is kept as simple and straightforward as possible
            // In the current context the code is "High quality" :) it all depends
            // since its purpose is to fulfil a single task once and
            // that you can check it as fast and as easy as possible. Cheers!

            // You need to change the default Windows console font to Consolas as well
            Console.OutputEncoding = Encoding.UTF8;
            var rssUrl = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";

            // Download the rss feed
            var webClient = new WebClient() { Encoding = Encoding.UTF8 };
            webClient.DownloadFile(rssUrl, "TelerikYTD_RSS.xml");

            // Load Xml from file
            var rssXml = new XmlDocument();
            rssXml.Load("TelerikYTD_RSS.xml");

            // Convert XmlDocument to JObject
            string xmlString = JsonConvert.SerializeXmlNode(rssXml, Newtonsoft.Json.Formatting.Indented);
            var jsonObj = JObject.Parse(xmlString);

            // Get video titles and print on the console
            var titles = jsonObj["feed"]["entry"]
                .Select(x => x["title"]);
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            // get videos as anonymous POCOs
            var videos = jsonObj["feed"]["entry"]
                .Select(x => 
                    new {
                        title = x["title"],
                        link = x["link"]["@href"],
                        id = x["yt:videoId"],
                        width = x["media:group"]["media:content"]["@width"],
                        height = x["media:group"]["media:content"]["@height"]
                    });

            // Generate the html string
            StringBuilder html = new StringBuilder();
            html.Append("<!DOCTYPE html><html><body>");
            foreach (var video in videos)
            {
                html.AppendFormat("<div style=\"padding: 12px; " +
                                  "margin:12px; background-color:lightgreen; border-radius:3px\">" +
                                  "<iframe width=\"{3}\" height=\"{4}\" style=\"display: block; margin: 0 auto;\" " +
                                  "src=\"http://www.youtube.com/embed/{1}?autoplay=0\" " +
                                  "frameborder=\"2px\" allowfullscreen></iframe>" +
                                  "<div style=\"text-align: center;\">" +
                                  "<h3>{2}</h3><a href=\"{0}\">See in YouTube</a></div></div>",
                                  video.link, video.id, video.title, video.width, video.height);
            }

            html.Append("</body></html>");

            // Save html string in soltion directory
            using (StreamWriter writer = new StreamWriter("../../../videos.html", false, Encoding.UTF8))
            {
                writer.Write(html);
            }
        }
    }
}
