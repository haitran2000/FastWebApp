using ATSCADAWebApp.Database.Access;
using ATSCADAWebApp.Model;
using ATSCADAWebApp.Database.Encryption;

namespace ATSCADAWebApp.Database.Service
{
    /// <summary>
    /// service truy cap xac thuc tai khoan
    /// </summary>
    public class AuthenticationService
    {
        private readonly ISqlAccess sqlAccess = new MySqlAccess();

        public string ConnectionString { get; set; } = "server=localhost;uid=root;pwd=100100;database=atscada";

        public AuthenticationService() { }

        public AuthenticationService(string connectionString)
        {
            ConnectionString = connectionString;
        }
        
        /// <summary>
        /// Kiem tra tai khoan co ton tai hay khong
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="account"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool CheckAccount(string tableName, AuthenticationAccount account, out string role)
        {
            role = string.Empty;
            if (tableName is null) return false;
            if (account is null) return false;
            try
            {                
                sqlAccess.ConnectionString = ConnectionString;
                var query = $"select `Role` from `{tableName}` where " +
                    $"`UserName` = '{account.UserName}' and " +
                    $"`Password` = '{account.Password.ToMD5()}' " +
                    $"limit 1;";

                var result = sqlAccess.ExecuteScalarQuery(query);
                if (result is null) return false;
                role = result.ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
