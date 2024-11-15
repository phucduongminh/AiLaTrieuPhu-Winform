using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Model
{
    internal class Questions
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public int QuestionType { get; set; }
        public int Answer { get; set; }

        public override string ToString()
        {
            return Question;
        }
    }
}
