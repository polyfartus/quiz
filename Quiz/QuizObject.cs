using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using MathObjects.Core.Plugin;
using MathObjects.Framework.Parser;
using MathObjects.Plugin.FloatingPoint;

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
                    if (q.IsChecked)
                    {
                        if (!q.MultipleChoice)
                        {
                            if (q.InputAnswerString == q.Answer1)
                            {
                                points += q.Points;
                            }
                        }
                        else
                        {
                            if (q.IsChecked && q.InputAnswer == q.Answer)
                            {
                                points += q.Points;
                            }
                        }
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

                    q = Parse(q);

                    int test = 0;
                    int.TryParse(xmlReader.GetAttribute("answer"), out test);
                    q.Answer = test;
                    q.Picture = xmlReader.GetAttribute("picture");
                    q.SolutionPicture = xmlReader.GetAttribute("solutionPicture");

                    q.MultipleChoice = true;
                    if (xmlReader.GetAttribute("multipleChoice") != null &&
                        xmlReader.GetAttribute("multipleChoice") == "false")
                    {
                        q.MultipleChoice = false;
                    }

                    quiz.Questions.Add(q);
                }
            }

            return quiz;
        }

        static QuestionObject Parse(QuestionObject q)
        {
            var plugin = new MathObjects.Plugin.FloatingPoint.Plugin();

            var loader = new PluginLoader();

            plugin.Startup(loader);

            var parser = (plugin as IHasParser).Parser;

            var stack = new MathObjectStack();
            var scope = new MathScope();

            System.Diagnostics.Debug.WriteLine(q.Text);
            q.Text = Parse(parser, stack, scope, q.Text);
            System.Diagnostics.Debug.WriteLine(q.Text);

            System.Diagnostics.Debug.WriteLine(q.Answer1);
            q.Answer1 = Parse(parser, stack, scope, q.Answer1);
            System.Diagnostics.Debug.WriteLine(q.Answer1);

            System.Diagnostics.Debug.WriteLine(q.Answer2);
            q.Answer2 = Parse(parser, stack, scope, q.Answer2);
            System.Diagnostics.Debug.WriteLine(q.Answer2);

            System.Diagnostics.Debug.WriteLine(q.Answer3);
            q.Answer3 = Parse(parser, stack, scope, q.Answer3);
            System.Diagnostics.Debug.WriteLine(q.Answer3);

            System.Diagnostics.Debug.WriteLine(q.Answer4);
            q.Answer4 = Parse(parser, stack, scope, q.Answer4);
            System.Diagnostics.Debug.WriteLine(q.Answer4);

            return q;
        }

        static string[] Split(string data)
        {
            var result = new List<string>();

            string last = "";

            foreach (var c in data.ToCharArray())
            {
                if (c == '{' || c == '}')
                {
                    if (last.Length > 0)
                    {
                        result.Add(last);
                        last = "";
                    }

                    result.Add("" + c);
                }
                else
                {
                    last += "" + c;
                }
            }

            if (last.Length > 0)
            {
                result.Add(last);
            }

            return result.ToArray();
        }

        static string Parse(
            IParser parser,
            MathObjectStack stack, 
            MathScope scope,
            string data)
        {
            if (data == null)
            {
                return "";
            }

            var parts = Split(data);

            string result = "";

            bool evaluate = false;
            foreach(var s in parts)
            {
                if (s == "{")
                {
                    evaluate = true;
                    continue;
                }

                if (s == "}")
                {
                    evaluate = false;
                    continue;
                }

                if (evaluate)
                {
                    result += Evaluate(parser, stack, scope, s);
                }
                else
                {
                    result += s;
                }
            }

            return result;
        }

        static string Evaluate(
            IParser parser,
            MathObjectStack stack, 
            MathScope scope,
            string data)
        {
            var clean = data.Trim(new char[] {'{', '}'});

            parser.Parse(clean, stack, scope);

            var answer = stack.Top.GetDouble();

            return String.Format("{0:0.##}", answer);
        }
    }
}

