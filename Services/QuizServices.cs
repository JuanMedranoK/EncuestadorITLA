using Services.EntitiesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Services
{
    public class QuizServices
    {
        Quiz quiz = new Quiz();
        QuizRepository quizRepository = new QuizRepository();

        public int AddQuiz(User user, string Nombre)
        {
            quiz.ID_USER = user.ID_USER;
            quiz.NAME = Nombre;
            if (!quizRepository.Add(quiz))
            {
                return 0;
            }
            DataTable dt = quizRepository.GetSpecific("Select MAX(ID_QUIZ) AS ID FROM QUIZ");
            int result = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
            return result;
        }
        public void Delete(int id)
        {
            quizRepository.Delete(id);
        }
        public DataTable getSpecific(string query)
        {
            return quizRepository.GetSpecific(query);
        }
    }
}
