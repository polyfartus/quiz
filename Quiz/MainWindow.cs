using System;
using Gtk;
using Quiz;
using System.Xml;
using System.IO;

public partial class MainWindow: Gtk.Window
{
    public MainWindow () : base (Gtk.WindowType.Toplevel)
    {
        Build ();

        this.buttonTake.Sensitive = false;

        this.fileswidget2.Selected += (sender, e) => 
            {
                EnableButtons();
            };
    }

    void EnableButtons()
    {
        var path = this.fileswidget2.SelectedPath;

        if (path != null)
        {
            if (File.Exists(path))
            {
                this.buttonTake.Sensitive = true;
            }
            else
            {
                this.buttonTake.Sensitive = false;
            }
        }
        else
        {
            this.buttonTake.Sensitive = false;
        }
    }

    protected void OnDeleteEvent (object sender, DeleteEventArgs a)
    {
        Application.Quit ();
        a.RetVal = true;
    }

    protected void OnButtonTakeClicked (object sender, EventArgs e)
    {
        var win = new QuizWindow();

        var selected = this.fileswidget2.SelectedPath;

        if (selected != null)
        {
            var path = System.IO.Path.GetFullPath(selected);

            if (File.Exists(path))
            {
                using (TextReader reader = File.OpenText(path))
                {
                    win.Quiz = LoadQuiz(reader);
                }

                win.Show();
            }
        }
    }

    static QuizObject LoadQuiz(TextReader reader)
    {
        var quiz = new QuizObject();

        var xmlReader = XmlReader.Create(reader);
        while(xmlReader.Read())
        {
            if( (xmlReader.NodeType == XmlNodeType.Element) && 
                (xmlReader.Name == "question"))
            {
                var q = new QuestionObject(); 

                q.Text = xmlReader.GetAttribute("text");
                q.Answer1 = xmlReader.GetAttribute("answer1");
                q.Answer2 = xmlReader.GetAttribute("answer2");
                q.Answer3 = xmlReader.GetAttribute("answer3");
                q.Answer4 = xmlReader.GetAttribute("answer4");
                q.Answer = int.Parse(xmlReader.GetAttribute("answer"));

                quiz.Questions.Add(q);
            }
        }

        return quiz;
    }

/*
    static QuizObject LoadQuiz()
    {
        var quiz = new QuizObject();

        {
            var q = new QuestionObject();
            q.Text = "An object goes from one point in space to another. After it arrives at its destination, its displacement is";
            q.Answer1 = "either greater than or equal to the distance it traveled.";
            q.Answer2 = "always greater than the distance it traveled.";
            q.Answer3 = "always equal to the distance it traveled.";
            q.Answer4 = "either smaller than or equal to the distance it traveled.";
            q.Answer = 4;
            quiz.Questions.Add (q);
        }

        {
            var q = new QuestionObject();
            q.Text = "A car has a negative acceleration of -4.2m/sec^2. We can say magnitude of the car’s velocity is";
            q.Answer1 = "constant.";
            q.Answer2 = "increasing.";
            q.Answer3 = "decreasing.";
            q.Answer4 = "We can’t really say from the information given.";
            q.Answer = 4;
            quiz.Questions.Add (q);
        }

        {
            var q = new QuestionObject();
            q.Text = "A physics student is moving to the right (with the positive direction to the + right). She originally is walking at 1 m/sec, but in a period of 2 seconds, she speeds up to a jog of 3 m/sec. What is her acceleration?";
            q.Answer1 = "1.0 m/sec^2";
            q.Answer2 = "-1.0 m/sec^2";
            q.Answer3 = "4.0 m/sec^2";
            q.Answer4 = "none of the above";
            q.Answer = 1;
            quiz.Questions.Add (q);
        }

        return quiz;
    }
*/    
}
