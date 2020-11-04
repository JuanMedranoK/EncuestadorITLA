using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Database
{
    public sealed class DatabaseConnection
    {
        public SqlConnection connection { get; } = null;

        public static DatabaseConnection Instance { get; } = new DatabaseConnection();

        private DatabaseConnection()
        {
            connection = new SqlConnection("Data Source = localhost\\MYSQL; Initial Catalog = pokedex; Integrated Security = True;");
            
        }
    }
}
