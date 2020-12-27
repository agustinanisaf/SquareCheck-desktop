using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace SquareCheck_desktop.Private
{
    class PrivatePageController : MyController
    {
        public PrivatePageController(IMyView _myView) : base(_myView)
        {
        }

        public async void getUserData()
        {
            await ApiGenerator.PostMe(viewPrivateInfo);
        }

        private void viewPrivateInfo(HttpResponseBundle obj)
        {
            Console.WriteLine("\n\n\nUser : " + obj.getParsedObject<APIResponse<UserModel>>().Data.Email + "\n\n\n");
            getView().callMethod("showInfoUser", obj.getParsedObject<APIResponse<UserModel>>().Data);
        }
    }
}
