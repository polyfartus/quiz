using System;

namespace Quiz
{
    public partial class QuizWindow : Gtk.Window
    {
        readonly QuizObject quiz;

        public QuizWindow(QuizObject quiz)
            : base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            this.quiz = quiz;
            this.quizwidget2.Quiz = quiz;
        }

        public QuizObject Quiz
        {
            get { return this.quiz; }
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

            score.LifeLongPoints += this.quizwidget2.Quiz.Points;

            score.Save();

            this.Destroy();
        }
    }
}

