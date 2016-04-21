using System;
using Gtk;
using Quiz;
using System.Xml;
using System.IO;
using Pango;
using MathObjects.Plugin.FloatingPoint;

public partial class MainWindow: Gtk.Window
{
    public MainWindow () : base (Gtk.WindowType.Toplevel)
    {
        Build ();

        this.buttonTake.Sensitive = false;

        this.textview1.ModifyFont(FontDescription.FromString("Courier 14"));

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
        var selected = this.fileswidget2.SelectedPath;

        if (selected != null)
        {
            var path = System.IO.Path.GetFullPath(selected);

            if (File.Exists(path))
            {
                try
                {
                    QuizObject obj = null;

                    using (TextReader reader = File.OpenText(path))
                    {
                        obj = QuizObject.LoadQuiz(reader, path);
                    }

                    var win = new QuizWindow();
                    win.Quiz = obj;

                    win.ShowNow();

                    win.Hidden += (sender2, e2) => 
                    {
                        this.EnableButtons();
                    };
                }
                catch (ParserException e2)
                {
                    var msg = e2.Descriptions[0].ToString();

                    var dlg = new Gtk.MessageDialog(
                                  this, DialogFlags.DestroyWithParent, MessageType.Error, 
                        ButtonsType.Close, "{0}", msg);

                    dlg.Run();
                    dlg.Destroy();
                }
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
