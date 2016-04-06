using System;
using Pango;

namespace Quiz
{
    [System.ComponentModel.ToolboxItem (true)]
    public partial class QuizWidget : Gtk.Bin
    {
        QuizObject quiz;

        QuestionObject current;

        public QuizWidget ()
        {
            this.Build ();

            this.textview1.ModifyFont (FontDescription.FromString("Courier 16"));
            this.textStatus.ModifyFont (FontDescription.FromString("Courier 16"));
            this.radiobutton1.ModifyFont (FontDescription.FromString("Courier 14"));
            this.radiobutton2.ModifyFont (FontDescription.FromString("Courier 14"));
            this.radiobutton3.ModifyFont (FontDescription.FromString("Courier 14"));
            this.radiobutton4.ModifyFont (FontDescription.FromString("Courier 14"));
            this.label1.ModifyFont(FontDescription.FromString("Courier 16"));
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

        void ShowQuestion()
        {
            int index = this.quiz.Questions.IndexOf(this.current);

            this.textview1.Buffer.Text = "" + (index+1) + ".  " + 
                this.current.Text + 
                "\n\nPoints: " + this.current.Points;

            this.radiobutton1.Label = this.current.Answer1;
            this.radiobutton2.Label = this.current.Answer2;
            this.radiobutton3.Label = this.current.Answer3;
            this.radiobutton4.Label = this.current.Answer4;
            this.textStatus.Buffer.Text = "";
            this.radiobutton1.Active = true;

            this.textStatus.Buffer.Text = this.current.StatusMessage;

            this.label1.Text = "Points: " + this.quiz.Points + "";

            SetSelected(this.current.InputAnswer);

            if (this.current.IsChecked)
            {
                this.radiobutton1.Sensitive = false;
                this.radiobutton2.Sensitive = false;
                this.radiobutton3.Sensitive = false;
                this.radiobutton4.Sensitive = false;
                this.buttonCheck.Sensitive = false;
            }
            else
            {
                this.radiobutton1.Sensitive = true;
                this.radiobutton2.Sensitive = true;
                this.radiobutton3.Sensitive = true;
                this.radiobutton4.Sensitive = true;
                this.buttonCheck.Sensitive = true;
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
            int selected = GetSelected ();

            string msg;

            if (selected == this.current.Answer) 
            {
                msg = "Correct";
            } 
            else 
            {
                msg = "Wrong. the answer is " + this.current.Answer;
            }

            this.textStatus.Buffer.Text = msg;
            this.current.IsChecked = true;
            this.current.StatusMessage = msg;
            this.current.InputAnswer = selected;

            this.ShowQuestion();
        }

        int GetSelected()
        {
            if (this.radiobutton1.Active) 
            {
                return 1;
            }

            if (this.radiobutton2.Active) 
            {
                return 2;
            }

            if (this.radiobutton3.Active) 
            {
                return 3;
            }

            if (this.radiobutton4.Active) 
            {
                return 4;
            }

            return 0;
        }

        void SetSelected(int index)
        {
            switch (index)
            {
                case 2:
                    this.radiobutton2.Active = true; 
                    break;
                case 3:
                    this.radiobutton3.Active = true; 
                    break;
                case 4:
                    this.radiobutton4.Active = true; 
                    break;
                default:
                    this.radiobutton1.Active = true; 
                    break;
            }
        }
    }
}

