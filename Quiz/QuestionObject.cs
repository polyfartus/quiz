using System;

namespace Quiz
{
    public class QuestionObject
    {
        string text, answer1, answer2, answer3, answer4;

        string statusMessage = "";

        int answer, inputAnswer;

        bool isChecked;

        public int Points
        {
            get;
            set;
        }

        public string Picture
        {
            get;
            set;
        }

        public string StatusMessage
        {
            get { return this.statusMessage; }
            set { this.statusMessage = value; }
        }

        public bool IsChecked
        {
            get { return this.isChecked; }
            set { this.isChecked = true; }
        }

        public string Text 
        { 
            get { return this.text; } 
            set { this.text=value; } 
        }

        public string Answer1 
        {
            get { return this.answer1; } 
            set { this.answer1=value; } 
        }

        public string Answer2 
        { 
            get { return this.answer2; } 
            set { this.answer2=value; } 
        }

        public string Answer3 
        { 
            get { return this.answer3; } 
            set { this.answer3=value; } 
        }

        public string Answer4 
        { 
            get { return this.answer4; } 
            set { this.answer4=value; } 
        }

        public int Answer 
        { 
            get { return this.answer; } 
            set { this.answer=value; } 
        }

        public int InputAnswer 
        { 
            get { return this.inputAnswer; } 
            set { this.inputAnswer=value; } 
        }
    }
}

