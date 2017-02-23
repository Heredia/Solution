using Helper.Security;

namespace Model.Models
{
    public class LoginModel
    {
        public string Login { get; set; }

        public string LoginHash => HashHelper.GenerateHash(Login);

        public string Password { get; set; }

        public string PasswordHash => HashHelper.GenerateHash(Password);
    }
}