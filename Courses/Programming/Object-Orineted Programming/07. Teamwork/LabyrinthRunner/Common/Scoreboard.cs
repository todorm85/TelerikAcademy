namespace LabyrinthRunner.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    public class Scoreboard : IScoreboard
    {
        private const byte MaxScoreboardEntries = 10;
        private const string FilePath = @"..\..\..\scoreboard.xml";

        public Scoreboard()
        {
            if (!File.Exists(FilePath))
            {
                XDocument xDoc = new XDocument(
                            new XDeclaration("1.0", "UTF-16", null),
                            new XElement("Players"));

                xDoc.Save(FilePath);
            }
        }

        public void Add(string userName, int score)
        {
            if (!IsScoreSavable(userName, score))
            {
                return;
            }

            XElement root = XElement.Load(FilePath);

            XElement lastPlayerNode = (XElement)root.LastNode;
            int lastPlayerScore = 0;
            try
            {
                lastPlayerScore = int.Parse(lastPlayerNode.Element("Score").Value);
            }
            catch (NullReferenceException) { }
            finally
            {
                if (score > lastPlayerScore)
                {
                    if (root.Elements("Player").Count() == MaxScoreboardEntries)
                    {
                        root.Elements("Player").Last().Remove();
                    }
                    root.Add(new XElement(
                                            "Player",
                                            new XElement("Username", userName),
                                            new XElement("Score", score),
                                            new XElement("Date", DateTime.Now.ToString())
                                         )
                            );
                    var sortedScores = root.Elements("Player")
                                           .OrderByDescending(xScore => (int)xScore.Element("Score"))
                                           .ToArray();
                    root.RemoveAll();
                    foreach (XElement sortedScore in sortedScores)
                    {
                        root.Add(sortedScore);
                    }
                    root.Save(FilePath);
                }
            }
        }

        public string Show()
        {
            // TODO: Proper formatting

            XElement root = XElement.Load(FilePath);
            IEnumerable<XElement> players = root.Elements();
            StringBuilder result = new StringBuilder();

            foreach (var player in players)
            {
                result.AppendLine(string.Format("{0} - {1} - {2}", player.Element("Username").Value, player.Element("Score").Value, player.Element("Date").Value));
            }

            return result.ToString();
        }


        public bool IsScoreSavable(string name, int score)
        {
            XElement root = XElement.Load(FilePath);
            bool isHighScore = root.Elements("Player").Where(x => int.Parse(x.Element("Score").Value) < score).Any();
            bool hasScorePlace = root.Elements("Player").ToList().Count < 10;
            return isHighScore || hasScorePlace;
        }
    }
}
