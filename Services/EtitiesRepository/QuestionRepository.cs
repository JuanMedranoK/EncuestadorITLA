using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Services.EntitiesRepository
{
    public class QuestionRepository : Repository, IRepository<Question>
    {
        
        public bool Add(Question item)
        {
            SqlCommand command = new SqlCommand("INSERT INTO QUESTIONS(ID_QUIZ, QUESTION) "
                                               + "VALUES(@IdQuiz, @Question)"
                                               , DatabaseConnection.Instance.connection);
            command.Parameters.AddWithValue("@IdQuiz", item.ID_QUIZ);
            command.Parameters.AddWithValue("@Question", item.QUESTION);

            return ExecuteDml(command);
        }

        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE QUESTIONS WHERE ID_QUESTION = @ID"
                                               , DatabaseConnection.Instance.connection);
            command.Parameters.AddWithValue("@ID", id);

            return ExecuteDml(command);
        }

        public bool Edit(Question item)
        {
            SqlCommand command = new SqlCommand("UPDATE QUESTIONS Set QUESTION = @question WHERE ID_QUESTION = @ID"
                                               , DatabaseConnection.Instance.connection);
            command.Parameters.AddWithValue("@question", item.QUESTION);
            command.Parameters.AddWithValue("@ID", item.ID_QUESTION);

            return ExecuteDml(command);
        }


        public DataTable GetSpecific(string query)
        {
            return ExecuteRead(query);
        }
    }
}
