using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Quiz
{
    public class QuizObject
    {
        readonly List<QuestionObject> questions;

        public QuizObject()
        {
            questions = new List<QuestionObject>();
        }

        public List<QuestionObject> Questions
        {
            get { return this.questions; }
        }

        public string Path
        {
            get;
            set;
        }

        public int Points
        {
            get
            {
                int points = 0;

                foreach (var q in this.questions)
                {
                    if (q.IsChecked && q.InputAnswer == q.Answer)
                    {
                        points += q.Points;
                    }
                }

                return points;
            }
        }

        public void Save(TextWriter textWriter)
        {
            using (var writer = XmlWriter.Create(textWriter))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("quiz");
                writer.WriteElementString("points", "" + this.Points);

                foreach (var q in this.questions)
                {
                    writer.WriteStartElement("question");
                    
                    writer.WriteElementString(
                        "correct", (q.Answer == q.InputAnswer) ? "true" : "false");
                    writer.WriteElementString("text", q.Text);
                    writer.WriteElementString("inputAnswer", "" + q.InputAnswer);
                    writer.WriteElementString("answer", "" + q.Answer);
                    writer.WriteElementString("points", "" + q.Points);
                    
                    writer.WriteEndElement();
                }
                
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }        
        }

        static public QuizObject LoadQuiz(TextReader reader, string path)
        {
            var quiz = new QuizObject();

            quiz.Path = path;

            var xmlReader = XmlReader.Create(reader);
            while(xmlReader.Read())
            {
                if( (xmlReader.NodeType == XmlNodeType.Element) && 
                   (xmlReader.Name == "question"))
                {
                    var q = new QuestionObject(); 

                    q.Points = int.Parse(xmlReader.GetAttribute("points"));
                    q.Text = xmlReader.GetAttribute("text");
                    q.Answer1 = xmlReader.GetAttribute("answer1");
                    q.Answer2 = xmlReader.GetAttribute("answer2");
                    q.Answer3 = xmlReader.GetAttribute("answer3");
                    q.Answer4 = xmlReader.GetAttribute("answer4");
                    q.Answer = int.Parse(xmlReader.GetAttribute("answer"));
                    q.Picture = xmlReader.GetAttribute("picture");

                    quiz.Questions.Add(q);
                }
            }

            return quiz;
        }
    }
}

