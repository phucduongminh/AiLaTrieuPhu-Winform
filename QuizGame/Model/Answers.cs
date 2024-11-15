using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Model
{
    internal class Answers
    {
        public int AnswerID { get; set; }
        public string Answer { get; set; }

        public override string ToString()
        {
            return Answer;
        }
    }
}
