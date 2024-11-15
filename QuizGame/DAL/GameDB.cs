using QuizGame.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.DAL
{
    internal class GameDB
    {
        public static SqlConnection _conn;

        public GameDB()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QuizGame"].ConnectionString);
            Questions = new QuestionManager();
            Answers = new AnswerManager();
            Types = new TypeManager();
        }

        public AnswerManager Answers { get; set; }
        public QuestionManager Questions { get; set; }
        public TypeManager Types { get; set; }
    }
}
