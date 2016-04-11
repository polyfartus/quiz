using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace Quiz
{
    public class ScoreObject2
    {
        public int Points
        {
            get;
            set;
        }

        public int LifeLongPoints
        {
            get;
            set;
        }

        public void Save()
        {
            File.WriteAllLines("score.xml", new List<string>());

            using (var textWriter = File.OpenWrite("score.xml"))
            {
                var writer = XmlWriter.Create(textWriter);
                
                writer.WriteStartDocument();
                writer.WriteStartElement("score");
                writer.WriteAttributeString("value", "" + this.Points);
                writer.WriteAttributeString("lifelongValue", "" + this.LifeLongPoints);
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();

                textWriter.Flush();
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
                        var value = xmlReader.GetAttribute("value");

                        if (value != null && value.Trim().Length > 0)
                        {
                            obj.Points = int.Parse(value);
                        }

                        var lifelongValue = xmlReader.GetAttribute("lifelongValue");
                        
                        if (lifelongValue != null && lifelongValue.Trim().Length > 0)
                        {
                            obj.LifeLongPoints = int.Parse(lifelongValue);
                        }
                    }
                }

                xmlReader.Close();
            }

            return obj;
        }
    }
}

