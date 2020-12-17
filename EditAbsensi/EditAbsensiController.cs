using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;
using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;

namespace SquareCheck_desktop.EditAbsensi
{
    public class EditAbsensiController : MyController
    {
        public EditAbsensiController(IMyView _myView) : base(_myView)
        {

        }

        public async void update(ScheduleModel schedule, AttendanceModel attendance)
        {
            await ApiGenerator.EditAttendance(viewOnUpdate, schedule.Id, attendance);
        }

        public void viewOnUpdate(HttpResponseBundle response)
        {
            if (response.getHttpResponseMessage().Content != null)
            {
                getView().callMethod("showUpdateSuccess");
            } else
            {
                //
            }
        }
    }
}
