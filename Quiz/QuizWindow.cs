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
            get { return this.quizwidget2.Quiz; }

            set { this.quizwidget2.Quiz = value; }
        }

        protected void OnButtonCloseClicked (object sender, EventArgs e)
        {
            var date = System.DateTime.Now;

            string post = "-" + date.ToShortDateString() + 
                "-" + date.Ticks + ".result";

            post = post.Replace("/", "-");

            string path = this.quizwidget2.Quiz.Path + post;

            using (var stream = System.IO.File.CreateText(path))
            {
                this.quizwidget2.Quiz.Save(stream);
            }

            var score = ScoreObject2.Load();

            score.Points += this.quizwidget2.Quiz.Points;

            score.Save();

            this.Destroy();
        }
    }
}

