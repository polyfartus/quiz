using System;
using Pango;
using Gtk;

namespace Quiz
{
    [System.ComponentModel.ToolboxItem (true)]
    public partial class QuizWidget : Gtk.Bin
    {
        QuizObject quiz;

        QuestionObject current;

        readonly AnswerUIMediator mediator;

        public QuizWidget ()
        {
            this.Build ();

            this.textview1.ModifyFont (FontDescription.FromString("Courier 16"));
            this.label1.ModifyFont (FontDescription.FromString("Courier 16"));
            this.textStatus.ModifyFont (FontDescription.FromString("Courier 18"));

            this.mediator = new AnswerUIMediator(this);
        }

        public QuestionObject Current
        {
            get { return this.current; }
        }

        public QuizObject Quiz
        {
            get { return this.quiz; }

            set
            { 
                this.quiz = value; 
                this.current = this.quiz.Questions[0]; 
                ShowQuestion (); 
            }
        }

        public RadioButton Radiobutton1
        {
            get { return this.radiobutton1;  }
        }

        public RadioButton Radiobutton2
        {
            get { return this.radiobutton2;  }
        }

        public RadioButton Radiobutton3
        {
            get { return this.radiobutton3;  }
        }

        public RadioButton Radiobutton4
        {
            get { return this.radiobutton4;  }
        }

        public Entry Entry1
        {
            get { return this.entry1; }
        }

        void ShowQuestion()
        {
            int index = this.quiz.Questions.IndexOf(this.current);

            this.textview1.Buffer.Text = "" + (index+1) + ".  " + 
                this.current.Text + 
                "\n\nPoints: " + this.current.Points;

            this.textStatus.Buffer.Text = "";

            this.textStatus.Buffer.Text = this.current.StatusMessage;

            this.label1.Text = "Points Earned: " + this.quiz.Points + "";

            if (this.current.IsChecked)
            {
                this.buttonCheck.Sensitive = false;
            }
            else
            {
                this.buttonCheck.Sensitive = true;
            }

            if (this.current.Picture != null && 
                this.current.Picture.Length > 0)
            {
                this.buttonPicture.Sensitive = true;
            }
            else
            {
                this.buttonPicture.Sensitive = false;
            }

            if (this.current.SolutionPicture != null && 
                this.current.SolutionPicture.Length > 0 &&
                this.current.IsChecked)
            {
                this.buttonSolution.Sensitive = true;
            }
            else
            {
                this.buttonSolution.Sensitive = false;
            }

            this.mediator.ShowQuestion();
        }

        protected void OnButtonSaveClicked (object sender, EventArgs e)
        {
            var date = new System.DateTime(); 

            string post = date.ToShortDateString() + date.ToShortTimeString();

            post = post.Replace("/", "-");

            string path = this.quiz.Path + post;

            using (var stream = System.IO.File.CreateText(path))
            {
                this.quiz.Save(stream);
            }
        }

        protected void OnButtonCheckClicked (object sender, EventArgs e)
        {
            Check();
        }

        protected void OnButtonNextClicked (object sender, EventArgs e)
        {
            Next();
        }
            
        protected void OnButtonPreviousClicked (object sender, EventArgs e)
        {
            Previous();
        }

        void Next()
        {
            int index = this.quiz.Questions.IndexOf(this.current);

            if (index == this.quiz.Questions.Count - 1)
            {
                this.current = this.quiz.Questions[0];
            }
            else
            {
                this.current = this.quiz.Questions[index + 1];
            }

            this.ShowQuestion();
        }

        void Previous()
        {
            int index = this.quiz.Questions.IndexOf(this.current);

            if (index == 0)
            {
                this.current = this.quiz.Questions[this.quiz.Questions.Count - 1];
            }
            else
            {
                this.current = this.quiz.Questions[index - 1];
            }

            this.ShowQuestion();
        }

        void Check()
        {
            string msg;

            if (this.current.MultipleChoice)
            {
                int selected = this.mediator.GetSelected();

                if (selected == this.current.Answer)
                {
                    msg = "Correct";
                }
                else
                {
                    msg = "Wrong. the answer is " + 
                        this.mediator.ConvertIndex(this.current.Answer);
                }

                this.textStatus.Buffer.Text = msg;
                this.current.IsChecked = true;
                this.current.StatusMessage = msg;
                this.current.InputAnswer = selected;
            }
            else
            {
                string input = this.entry1.Text.ToLower();
                
                if (input == this.current.Answer1)
                {
                    msg = "Correct";
                }
                else
                {
                    msg = "Wrong. the answer is " + this.current.Answer1;
                }
                
                this.textStatus.Buffer.Text = msg;
                this.current.IsChecked = true;
                this.current.StatusMessage = msg;
                this.current.InputAnswerString = input;
            }

            this.ShowQuestion();
        }

        protected void OnButtonPictureClicked (object sender, EventArgs e)
        {
            var dlg = new PictureDlg(this.current.Picture);

            dlg.Show();

            dlg.Run();

            dlg.Destroy();
        }

        protected void OnButtonSolutionClicked (object sender, EventArgs e)
        {
            var dlg = new PictureDlg(this.current.SolutionPicture);
            
            dlg.Show();
            
            dlg.Run();
            
            dlg.Destroy();
        }
    }
}

