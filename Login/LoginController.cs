using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Basic;
using Velacro.Api;
using System.Net.Http;
using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;

namespace SquareCheck_desktop.Login
{
    public class LoginController : MyController
    {
        public LoginController(IMyView _myView) : base(_myView) { }

        public async void Login(string _email, string _password)
        {
            try
            {
                await ApiGenerator.PostLogin(viewOnLogin, new UserModel(_email, _password));
            }
            catch (HttpRequestException err)
            {
                Console.WriteLine(err);
            }
        }

        public void viewOnLogin(HttpResponseBundle response)
        {
            if (response.getHttpResponseMessage().Content != null)
            {
                ApiGenerator.Token = response.getParsedObject<TokenModel>().Token;
                getView().callMethod("ShowLoginSuccess");
            } else {
                // TODO: Create Error Message
                Console.WriteLine("Wrong Credentials");
            }
        }
    }
}
