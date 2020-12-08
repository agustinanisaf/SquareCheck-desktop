using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace SquareCheck_desktop.DetailKehadiranMatakuliah
{
    class DetailKehadiranMatakuliahController : MyController
    {
        public DetailKehadiranMatakuliahController(IMyView _myView) : base(_myView)
        {
        }

        public async void getData(int id)
        {
            await ApiGenerator.GetScheduleListAttendance(viewListMahasiswaController, id);
        }

        private void viewListMahasiswaController(HttpResponseBundle obj)
        {
            Console.WriteLine("Res : " + obj);

            getView().callMethod("showListMahasiswa", obj.getParsedObject<APIResponse<List<AttendanceModel>>>().Data);

        }
    }
}
