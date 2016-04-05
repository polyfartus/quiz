using System;

namespace Quiz
{
    public partial class QuizWindow : Gtk.Window
    {
        public QuizWindow()
            : base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        public QuizObject Quiz
        {
            get { return this.quizwidget1.Quiz; }

            set { this.quizwidget1.Quiz = value; }
        }


    }
}

