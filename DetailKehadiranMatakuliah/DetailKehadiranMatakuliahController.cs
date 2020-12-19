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
            List<AttendanceModel> model = obj.getParsedObject<APIResponse<List<AttendanceModel>>>().Data;
            List<AttendanceModel> result = new List<AttendanceModel>();
            DateTime date;

            foreach (var key in model)
            {
                date = Convert.ToDateTime(key.Time);
                key.Time = date.ToString("HH:mm");
                result.Add(key);
            }

            getView().callMethod("showListMahasiswa", result);

        }
    }
}
