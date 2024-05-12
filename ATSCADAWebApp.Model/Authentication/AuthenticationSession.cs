namespace ATSCADAWebApp.Model
{
    public class AuthenticationSession
    {
        public string UserName { get; set; }

        public string Role { get; set; }

        public AuthenticationSession(string userName, string role)
        {
            UserName = userName;
            Role = role;
        }
    }
}
