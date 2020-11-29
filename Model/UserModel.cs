namespace SquareCheck_desktop.Model
{
    public class UserModel
    {
        public UserModel()
        {

        }

        public UserModel(string _email, string _password)
        {
            this.Email = _email;
            this.Password = _password;
        }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
