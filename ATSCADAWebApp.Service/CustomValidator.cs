using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace ATSCADAWebApp.Service
{
    public class CustomValidator : UserNamePasswordValidator
    {
        // Xác thực Client mỗi lần request. Kiểm tra UserName và Password có khớp hay không
        public override void Validate(string userName, string password)
        {
            if ((userName != Account.UserName) || (password != Account.Password))
            {
                throw new SecurityTokenException("Validation Failed!");
            }
        }
    }
}
