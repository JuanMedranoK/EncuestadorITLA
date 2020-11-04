using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Database;

namespace Services.EntitiesRepository
{
    public class QuizRepository : Repository, IRepository<Quiz>
    {
        public bool Add(Quiz item)
        {
            SqlCommand command = new SqlCommand("INSERT INTO QUIZ(NAME, ID_USER) "
                                               + "VALUES(@name, @ID)"
                                               , DatabaseConnection.Instance.connection);
            command.Parameters.AddWithValue("@name", item.NAME);
            command.Parameters.AddWithValue("@ID", item.ID_USER);

            return ExecuteDml(command);
        }

        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE QUIZ WHERE ID_QUIZ = @ID"
                                               , DatabaseConnection.Instance.connection);
            command.Parameters.AddWithValue("@ID", id);

            return ExecuteDml(command);
        }

        public bool Edit(Quiz item)
        {
            SqlCommand command = new SqlCommand("UPDATE QUIZ(NAME = @name) WHERE ID_QUIZ = @ID"
                                               , DatabaseConnection.Instance.connection);
            command.Parameters.AddWithValue("@name", item.NAME);
            command.Parameters.AddWithValue("@ID", item.ID_QUIZZ);

            return ExecuteDml(command);
        }


        public DataTable GetSpecific(string query)
        {
            return ExecuteRead(query);
        }
    }
}
