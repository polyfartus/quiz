﻿using System;
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
            this.label1.ModifyFont (FontDescription.FromString("Courier 16"));
            this.textStatus.ModifyFont (FontDescription.FromString("Courier 18"));
            this.radiobutton1.ModifyFont (FontDescription.FromString("Courier 14"));
            this.radiobutton2.ModifyFont (FontDescription.FromString("Courier 14"));
            this.radiobutton3.ModifyFont (FontDescription.FromString("Courier 14"));
            this.radiobutton4.ModifyFont (FontDescription.FromString("Courier 14"));
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

            this.label1.Text = "Points Earned: " + this.quiz.Points + "";

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

            if (this.current.Picture != null && this.current.Picture.Length > 0)
            {
                this.buttonPicture.Sensitive = true;
            }
            else
            {
                this.buttonPicture.Sensitive = false;
            }

            if (this.current.MultipleChoice)
            {
                this.radiobutton1.Show();
                this.radiobutton2.Show();
                this.radiobutton3.Show();
                this.radiobutton4.Show();
                this.entry1.Hide();
            }
            else
            {
                this.radiobutton1.Hide();
                this.radiobutton2.Hide();
                this.radiobutton3.Hide();
                this.radiobutton4.Hide();
                this.entry1.Show();
            }
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
                int selected = GetSelected();

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

        protected void OnButtonPictureClicked (object sender, EventArgs e)
        {
            var dlg = new PictureDlg(this.current.Picture);

            dlg.Show();

            dlg.Run();

            dlg.Destroy();
        }
    }
}

