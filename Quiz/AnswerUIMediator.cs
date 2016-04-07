using System;

namespace Quiz
{
    public class AnswerUIMediator
    {
        readonly QuizWidget widget;

        public AnswerUIMediator(QuizWidget widget)
        {
            this.widget = widget;
        }

        public void ShowQuestion()
        {
            this.widget.Radiobutton1.Label = this.widget.Current.Answer1;
            this.widget.Radiobutton2.Label = this.widget.Current.Answer2;
            this.widget.Radiobutton3.Label = this.widget.Current.Answer3;
            this.widget.Radiobutton4.Label = this.widget.Current.Answer4;

            this.widget.Radiobutton1.Active = true;

            SetSelected(this.widget.Current.InputAnswer);

            if (this.widget.Current.IsChecked)
            {
                this.widget.Radiobutton1.Sensitive = false;
                this.widget.Radiobutton2.Sensitive = false;
                this.widget.Radiobutton3.Sensitive = false;
                this.widget.Radiobutton4.Sensitive = false;
            }
            else
            {
                this.widget.Radiobutton1.Sensitive = true;
                this.widget.Radiobutton2.Sensitive = true;
                this.widget.Radiobutton3.Sensitive = true;
                this.widget.Radiobutton4.Sensitive = true;
            }

            if (this.widget.Current.MultipleChoice)
            {
                this.widget.Radiobutton1.Show();
                this.widget.Radiobutton2.Show();
                this.widget.Radiobutton3.Show();
                this.widget.Radiobutton4.Show();
                this.widget.Entry1.Hide();
            }
            else
            {
                this.widget.Radiobutton1.Hide();
                this.widget.Radiobutton2.Hide();
                this.widget.Radiobutton3.Hide();
                this.widget.Radiobutton4.Hide();
                this.widget.Entry1.Show();
            }
        }

        public int GetSelected()
        {
            if (this.widget.Radiobutton1.Active) 
            {
                return 1;
            }

            if (this.widget.Radiobutton2.Active) 
            {
                return 2;
            }

            if (this.widget.Radiobutton3.Active) 
            {
                return 3;
            }

            if (this.widget.Radiobutton4.Active) 
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
                    this.widget.Radiobutton2.Active = true; 
                    break;
                case 3:
                    this.widget.Radiobutton3.Active = true; 
                    break;
                case 4:
                    this.widget.Radiobutton4.Active = true; 
                    break;
                default:
                    this.widget.Radiobutton1.Active = true; 
                    break;
            }
        }
    }
}

