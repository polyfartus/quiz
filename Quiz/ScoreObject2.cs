using System;
using System.Xml;
using System.IO;

namespace Quiz
{
    public class ScoreObject2
    {
        public int Points
        {
            get;
            set;
        }

        public void Save()
        {
            var textWriter = File.OpenWrite("score.xml");

            using (var writer = XmlWriter.Create(textWriter))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("score");
                writer.WriteElementString("value", "" + this.Points);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }        
        }

        static public ScoreObject2 Load()
        {
            if (!File.Exists("score.xml"))
            {
                return new ScoreObject2();
            }

            var obj = new ScoreObject2();

            using (var reader = File.OpenText("score.xml"))
            {
                var xmlReader = XmlReader.Create(reader);
                while(xmlReader.Read())
                {
                    if( (xmlReader.NodeType == XmlNodeType.Element) && 
                        (xmlReader.Name == "score"))
                    {
                        obj.Points = int.Parse(xmlReader.GetAttribute("value"));
                    }
                }
            }

            return obj;
        }
    }
}

