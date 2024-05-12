using System.ComponentModel.DataAnnotations;

namespace ATSCADAWebApp.Model
{
    // Thong tin dang nhap login
    public class AuthenticationAccount
    {
        // Tai khoan
        [Required(ErrorMessage = "Please enter username")] // Yeu cau phai nhap
        public string UserName { get; set; }

        // Mat khau
        [Required(ErrorMessage = "Please enter password")] // Yeu cau phai nhap
        public string Password { get; set; }       
    }
}
