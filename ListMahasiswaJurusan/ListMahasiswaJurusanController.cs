using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;
using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;

namespace SquareCheck_desktop.ListMahasiswaJurusan
{
    public class ListMahasiswaJurusanController : MyController
    {
        public ListMahasiswaJurusanController(IMyView _myView) : base(_myView)
        {
        }

        public async void getData(int id)
        {
            await ApiGenerator.GetDepartmentListStudent(viewListMahasiswaController, id);
        }

        private void viewListMahasiswaController(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                getView().callMethod("showListMahasiswa", _response.getParsedObject<APIResponse<List<StudentModel>>>().Data);
            }
        }
    }
}
