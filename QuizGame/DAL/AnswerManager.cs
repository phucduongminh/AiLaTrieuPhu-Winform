using QuizGame.DAL;
using QuizGame.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.DAL
{
    internal class AnswerManager : ICRUD<Answers>
    {
        public List<Answers> Search(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Questions.QuestionID, Questions.Question, Questions.A, Questions.B, Questions.C, Questions.D, Questions.Answer, Answers.Answer, Questions.QuestionType, QuestionTypes.Type\r\nFROM     Answers INNER JOIN\r\n                  Questions ON Answers.AnswerID = Questions.Answer INNER JOIN\r\n                  QuestionTypes ON Questions.QuestionType = QuestionTypes.TypeID";
            cmd.Connection = GameDB._conn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Answers> answers = new List<Answers>();
            while (reader.Read())
            {
                Answers answer = new Answers();
                answer.Answer = reader.GetString(id);
                answers.Add(answer);
            }
            GameDB._conn.Close();
            return answers;
        }

        public List<Answers> ListOptionA()
        {
            GameDB._conn.Open();
            return Search(2);
        }

        public List<Answers> ListOptionB()
        {
            GameDB._conn.Open();
            return Search(3);
        }

        public List<Answers> ListOptionC()
        {
            GameDB._conn.Open();
            return Search(4);
        }

        public List<Answers> ListOptionD()
        {
            GameDB._conn.Open();
            return Search(5);
        }

        public void Add(Answers entity)
        {
            throw new NotImplementedException();
        }

        public List<Answers> ListQuestions()
        {
            GameDB._conn.Open();
            return Search(9);
        }

        public List<Answers> ListAnswers()
        {
            GameDB._conn.Open();
            return Search(7);
        }

        public void UpdateCounters(int index)
        {
            Questions question = new Questions();
            QuestionManager questionManager = new QuestionManager();
            question.Question = questionManager.ListQuestions()[index].ToString();
            question.OptionA = ListOptionA()[index].ToString();
            question.OptionB = ListOptionB()[index].ToString();
            question.OptionC = ListOptionC()[index].ToString();
            question.OptionD = ListOptionD()[index].ToString();
        }
    }
}
