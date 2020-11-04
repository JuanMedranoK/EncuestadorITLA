using Services;
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
    public class UserRepository : Repository, IRepository<User>
    {
        public bool Add(User item)
        {
            SqlCommand command = new SqlCommand("INSERT INTO USERS(NAME, LASTNAME, USERNAME, PASSWORD) " 
                                               +"VALUES(@name, @lastname, @username, @password)"
                                               ,DatabaseConnection.Instance.connection);
            command.Parameters.AddWithValue("@name", item.NAME);
            command.Parameters.AddWithValue("@lastname", item.LASTNAME);
            command.Parameters.AddWithValue("@username", item.USER_NAME);
            command.Parameters.AddWithValue("@password", item.PASSWORD);

            return ExecuteDml(command);
        }

        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE USERS "
                                                + "WHERE ID_USER = @ID"
                                               , DatabaseConnection.Instance.connection);
            command.Parameters.AddWithValue("@ID", id);

            return ExecuteDml(command);
        }

        public bool Edit(User item)
        {
            SqlCommand command = new SqlCommand("UPDATE USERS SET NAME = @name, LASTNAME = @lastname, USERNAME = @username, PASSWORD = @password "
                                                + "WHERE ID_USER = @ID"
                                               , DatabaseConnection.Instance.connection);
            command.Parameters.AddWithValue("@ID", item.ID_USER);
            command.Parameters.AddWithValue("@name", item.NAME);
            command.Parameters.AddWithValue("@lastname", item.LASTNAME);
            command.Parameters.AddWithValue("@username", item.USER_NAME);
            command.Parameters.AddWithValue("@password", item.PASSWORD);

            return ExecuteDml(command);
        }

        public DataTable GetSpecific(string query)
        {
            return ExecuteRead(query);
        }

    }
}
