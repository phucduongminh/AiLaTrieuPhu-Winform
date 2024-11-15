using QuizGame.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.DAL
{
    internal class TypeManager : ICRUD<QuestionTypes>
    {
        public List<QuestionTypes> ListOptionA()
        {
            throw new NotImplementedException();
        }

        public List<QuestionTypes> Search(int id)
        {
            throw new NotImplementedException();
        }

        public List<QuestionTypes> ListOptionB()
        {
            throw new NotImplementedException();
        }

        public List<QuestionTypes> ListOptionC()
        {
            throw new NotImplementedException();
        }

        public List<QuestionTypes> ListOptionD()
        {
            throw new NotImplementedException();
        }

        public void Add(QuestionTypes entity)
        {
            throw new NotImplementedException();
        }

        public List<QuestionTypes> ListQuestions()
        {
            throw new NotImplementedException();
        }

        public List<QuestionTypes> ListTypes()
        {
            GameDB._conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Questions.QuestionID, Questions.Question, Questions.A, Questions.B, Questions.C, Questions.D, Questions.Answer, Answers.Answer, Questions.QuestionType, QuestionTypes.Type\r\nFROM     Answers INNER JOIN\r\n                  Questions ON Answers.AnswerID = Questions.Answer INNER JOIN\r\n                  QuestionTypes ON Questions.QuestionType = QuestionTypes.TypeID";
            cmd.Connection = GameDB._conn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<QuestionTypes> types = new List<QuestionTypes>();
            while (reader.Read())
            {
                QuestionTypes type = new QuestionTypes();
                type.Type = reader.GetString(9).ToString();
                types.Add(type);
            }
            GameDB._conn.Close();
            return types;
        }
    }
}
