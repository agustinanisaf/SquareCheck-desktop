using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace SquareCheck_desktop.DetailKehadiranMahasiswa
{
    class DetailKehadiranMahasiswaController : MyController
    {
        public DetailKehadiranMahasiswaController(IMyView _myView) : base(_myView)
        { 
        }

        public async void getListDetailKehadiranMahasiswa(int subjectId) 
        {
            try
            {
                await ApiGenerator.GetListDetailKehadiranMahasiswa(viewShowListDetailKehadiranMahasiswa, subjectId);
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void viewShowListDetailKehadiranMahasiswa(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                getView().callMethod("showListDetailKehadiranMahasiswa", _response.getParsedObject<APIResponse<List<AttendanceModel>>>().Data);
            }
        }
    }
}
