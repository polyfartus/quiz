using System;
using Gtk;

namespace Quiz
{
    public class AnswerUIMediator
    {
        readonly QuizWidget widget;

        readonly RadioButton[] buttons = new RadioButton[4];

        public AnswerUIMediator(QuizWidget widget)
        {
            this.widget = widget;

            buttons[0] = this.widget.Radiobutton1;
            buttons[1] = this.widget.Radiobutton2;
            buttons[2] = this.widget.Radiobutton3;
            buttons[3] = this.widget.Radiobutton4;
        }

        public void ShowQuestion()
        {
            buttons[0].Label = this.widget.Current.Answer1;
            buttons[1].Label = this.widget.Current.Answer2;
            buttons[2].Label = this.widget.Current.Answer3;
            buttons[3].Label = this.widget.Current.Answer4;

            this.widget.Radiobutton1.Active = true;

            SetSelected(this.widget.Current.InputAnswer);

            if (this.widget.Current.IsChecked)
            {
                buttons[0].Sensitive = false;
                buttons[1].Sensitive = false;
                buttons[2].Sensitive = false;
                buttons[3].Sensitive = false;
            }
            else
            {
                buttons[0].Sensitive = true;
                buttons[1].Sensitive = true;
                buttons[2].Sensitive = true;
                buttons[3].Sensitive = true;
            }

            if (this.widget.Current.MultipleChoice)
            {
                buttons[0].Show();
                buttons[1].Show();
                buttons[2].Show();
                buttons[3].Show();
                this.widget.Entry1.Hide();
            }
            else
            {
                buttons[0].Hide();
                buttons[1].Hide();
                buttons[2].Hide();
                buttons[3].Hide();
                this.widget.Entry1.Show();
            }
        }

        public int GetSelected()
        {
            if (buttons[0].Active) 
            {
                return 1;
            }

            if (buttons[1].Active) 
            {
                return 2;
            }

            if (buttons[2].Active) 
            {
                return 3;
            }

            if (buttons[3].Active) 
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
                    buttons[1].Active = true; 
                    break;
                case 3:
                    buttons[2].Active = true; 
                    break;
                case 4:
                    buttons[3].Active = true; 
                    break;
                default:
                    buttons[0].Active = true; 
                    break;
            }
        }
    }
}

