using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Database;

namespace Services.EntitiesRepository
{
    public class AnswerRepository : Repository, IRepository<Answer>
    {
        
        public bool Add(Answer item)
        {
            SqlCommand command = new SqlCommand("INSERT INTO ANSWERS(ID_QUESTION, NAME_PERSON, ID_USER, ANSWER) "
                                               + "VALUES(@IdQuestion, @NamePerson, @IdUser, @Answer)"
                                               , DatabaseConnection.Instance.connection);
            command.Parameters.AddWithValue("@IdQuestion", item.ID_QUESTION);
            command.Parameters.AddWithValue("@NamePerson", item.NAME_PERSON);
            command.Parameters.AddWithValue("@IdUser", item.ID_USER);
            command.Parameters.AddWithValue("@Answer", item.ANSWER);

            return ExecuteDml(command);
        }

        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE ANSWER WHERE ID_ANSWER = @ID"
                                               , DatabaseConnection.Instance.connection);
            command.Parameters.AddWithValue("@ID", id);

            return ExecuteDml(command);
        }

        public bool Edit(Answer item)
        {
            SqlCommand command = new SqlCommand("UPDATE ANSWER (ANSWER = @answer) WHERE ID_ANSWER = @ID"
                                               , DatabaseConnection.Instance.connection);
            command.Parameters.AddWithValue("@question", item.ANSWER);
            command.Parameters.AddWithValue("@ID", item.ID_ANSWER);

            return ExecuteDml(command);
        }


        public DataTable GetSpecific(string query)
        {
            return ExecuteRead(query);
        }
    }
}
