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
        private int subjectId;
        public DetailKehadiranMahasiswaController(IMyView _myView) : base(_myView)
        {
        }

        public async void getListDetailKehadiranMahasiswa(int studentId, int subjectId)
        {
            this.subjectId = subjectId;
            await ApiGenerator.GetStudentListAttendance(viewShowListDetailKehadiranMahasiswa, studentId);
        }

        private void viewShowListDetailKehadiranMahasiswa(HttpResponseBundle _response)
        {
            List<ScheduleModel> res, finalRes;

            if (_response.getHttpResponseMessage().Content != null)
            {
                res = new List<ScheduleModel>(_response.getParsedObject<APIResponse<List<ScheduleModel>>>().Data);
                finalRes = new List<ScheduleModel>();

                foreach (var key in res)
                {
                    if (key.Subject.Id.Equals(subjectId))
                        finalRes.Add(key);
                }
                Console.WriteLine(_response.getJObject());
                getView().callMethod("showListDetailKehadiranMahasiswa", finalRes);
            }
        }
    }
}
