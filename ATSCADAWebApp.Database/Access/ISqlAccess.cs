using System.Data;

namespace ATSCADAWebApp.Database.Access
{
    public interface ISqlAccess
    {
        string ConnectionString { get; set; }

        int ExecuteNonQuery(string query);

        int ExecuteNonQuery(string query, params object[] parameters);

        DataTable ExecuteQuery(string query);

        DataSet ExecuteQueryMulti(string query);

        object ExecuteScalarQuery(string query);

    }
}
