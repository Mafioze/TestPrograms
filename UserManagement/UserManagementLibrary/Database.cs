using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlLibrary
{
    public class Database : IDatabase
    {
        string connectionString = @"Data Source=МИХАИЛ-ПК;Initial Catalog=Management;Integrated Security=True";
        SqlConnection connection;

        public Database()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public IList<IDictionary<string, string>> ExecuteQuery(string sqlQuery)
        {
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            command.CommandText = sqlQuery;
            command.Connection = connection;
            reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                IList<IDictionary<string, string>> result = new List<IDictionary<string, string>>();

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add(reader.GetName(0), id.ToString());
                    dict.Add(reader.GetName(1), name.ToString());
                    result.Add(dict);
                }

                return result;
            }

            return null;
        }

    }
}
