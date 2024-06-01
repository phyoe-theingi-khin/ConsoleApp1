using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace PTKDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        //public AdoDotNetService(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        //{
        //    _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
        //}
        public AdoDotNetService( string connectionString)
        {
            _sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
        }

        public List<T> Query<T>(string query, List<SqlParameter>? parameter = null)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameter != null)
            {
                cmd.Parameters.AddRange(parameter.ToArray());
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            string json = JsonConvert.SerializeObject(dt);
            var lst = JsonConvert.DeserializeObject<List<T>>(json);
            return lst!;

        }
        public T QueryFirstOrDefault<T>(string query, List<SqlParameter>? parameter = null)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameter != null)
            {
                cmd.Parameters.AddRange(parameter.ToArray());
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            string json = JsonConvert.SerializeObject(dt);
            var lst = JsonConvert.DeserializeObject<List<T>>(json);
            return lst![0];

        }
        public int Execute(string query, List<SqlParameter>? parameter = null)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameter != null)
            {
                cmd.Parameters.AddRange(parameter.ToArray());
            }
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }
}
