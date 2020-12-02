using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Velacro.Api;
using Velacro.Basic;
using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;

namespace SquareCheck_desktop.ListMahasiswa
{
    public class ListMahasiswaController : MyController
    {
        public ListMahasiswaController(IMyView _myView) : base(_myView)
        {

        }

        public async void getListMahasiswa()
        {
            try
            {
                await ApiGenerator.GetListStudent(viewShowListMahasiswa);
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void viewShowListMahasiswa(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("showListMahasiswa", _response.getParsedObject<APIResponse<List<DepartmentSummaryModel>>>().Data);
            }
        }
    }
}
