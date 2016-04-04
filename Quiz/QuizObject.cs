using System;
using System.Linq;
using System.Collections.Generic;

namespace Quiz
{
    public class QuizObject
    {
        readonly List<QuestionObject> questions;

        public QuizObject()
        {
            questions = new List<QuestionObject>();
        }

        public List<QuestionObject> Questions
        {
            get { return this.questions; }
        }
    }
}

