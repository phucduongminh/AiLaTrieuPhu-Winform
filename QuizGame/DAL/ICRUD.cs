using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.DAL
{
    internal interface ICRUD<T> where T : class
    {
        void Add(T entity);
        List<T> ListQuestions();
        List<T> ListOptionA();
        List<T> ListOptionB();
        List<T> ListOptionC();
        List<T> ListOptionD();
        List<T> Search(int id);
    }
}
