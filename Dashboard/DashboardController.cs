using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Velacro.Api;
using Velacro.Basic;

namespace SquareCheck_desktop.Dashboard
{
    public class DashboardController : MyController
    {
        public DashboardController(IMyView _myView) : base(_myView)
        {

        }

        public async void GetDashboardData()
        {
            try
            {
                await ApiGenerator.GetListSubjectLimit(ViewShowListSubject, 3);
                await ApiGenerator.GetListStudentLimit(ViewShowListStudent, 3);
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void ViewShowListSubject(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("ShowListSubject", _response.getParsedObject<APIResponse<List<DepartmentSummaryModel>>>().Data);
            }
        }

        public void ViewShowListStudent(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("ShowListStudent", _response.getParsedObject<APIResponse<List<DepartmentSummaryModel>>>().Data);
            }
        }
    }
}
