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
    internal class QuestionManager : ICRUD<Questions>
    {
        public List<Questions> Search(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Questions.QuestionID, Questions.Question, Questions.A, Questions.B, Questions.C, Questions.D, Questions.Answer, Answers.Answer, Questions.QuestionType, QuestionTypes.Type\r\nFROM     Answers INNER JOIN\r\n                  Questions ON Answers.AnswerID = Questions.Answer INNER JOIN\r\n                  QuestionTypes ON Questions.QuestionType = QuestionTypes.TypeID";
            cmd.Connection = GameDB._conn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Questions> questions = new List<Questions>();
            while (reader.Read())
            {
                Questions question = new Questions();
                question.Question = reader.GetString(id);
                questions.Add(question);
            }
            GameDB._conn.Close();
            return questions;
        }

        public List<Questions> ListQuestions()
        {
            GameDB._conn.Open();
            return Search(1);
        }

        public List<Questions> ListOptionA()
        {
            throw new NotImplementedException();
        }

        public List<Questions> ListOptionB()
        {
            throw new NotImplementedException();
        }

        public List<Questions> ListOptionC()
        {
            throw new NotImplementedException();
        }

        public List<Questions> ListOptionD()
        {
            throw new NotImplementedException();
        }

        public void Add(Questions entity)
        {
            throw new NotImplementedException();
        }
    }
}
