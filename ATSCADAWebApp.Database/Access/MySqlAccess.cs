using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;

namespace ATSCADAWebApp.Database.Access
{
    /// <summary>
    /// Cac ham ho tro ket noi Mysql
    /// </summary>
    public class MySqlAccess : ISqlAccess
    {
        public string ConnectionString { get; set; }

        public MySqlAccess() { }

        public MySqlAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        #region COMMAND TEXT

        public int ExecuteNonQuery(string query)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int ExecuteNonQuery(string query, params object[] parameters)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    string[] querySplit = query.Split(' ');
                    string[] paramNames = querySplit.Where(x => x.StartsWith("@")).ToArray();

                    if (parameters.Length == paramNames.Length)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(paramNames[i], parameters[i]);
                        }
                        return cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    using (var dataAdapter = new MySqlDataAdapter(cmd))
                    {
                        var dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public DataSet ExecuteQueryMulti(string query)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    conn.Open();
                    using (var dataAdapter = new MySqlDataAdapter(cmd))
                    {
                        var dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);
                        return dataSet;
                    }
                }
            }
        }

        public object ExecuteScalarQuery(string query)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    return cmd.ExecuteScalar();
                }
            }
        }

        #endregion

    }
}
