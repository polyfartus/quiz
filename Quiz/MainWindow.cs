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
                    win.Quiz = QuizObject.LoadQuiz(reader, path);
                }

                win.Show();
            }
        }
    }
}
