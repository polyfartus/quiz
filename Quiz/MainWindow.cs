using System;
using Gtk;
using Quiz;
using System.Xml;
using System.IO;
using Pango;

public partial class MainWindow: Gtk.Window
{
    public MainWindow () : base (Gtk.WindowType.Toplevel)
    {
        Build ();

        this.buttonTake.Sensitive = false;

        this.textview1.ModifyFont(FontDescription.FromString("Courier 16"));

        this.fileswidget2.Selected += (sender, e) => 
            {
                EnableButtons();
            };

        EnableButtons();
    }

    void EnableButtons()
    {
        var path = this.fileswidget2.SelectedPath;

        var score = ScoreObject2.Load();

        string msg = "Points: " + score.Points +
            "\nLifelong Points: " + score.LifeLongPoints;

        this.textview1.Buffer.Text = msg;
        this.textview1.Show();

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
                    win.Quiz = QuizObject.LoadQuiz(reader, path);
                }

                win.ShowNow();

                win.Hidden += (sender2, e2) => 
                    {
                        this.EnableButtons();
                    };
            }
        }
    }

    protected void OnButtonCloseClicked (object sender, EventArgs e)
    {
        Application.Quit();

        this.Destroy();
    }

    protected void OnButtonResetClicked (object sender, EventArgs e)
    {
        var score = ScoreObject2.Load();

        score.Points = 0;

        score.Save();

        EnableButtons();
    }
}
