using System;
using System.Collections.Generic;
using System.Net.Http;
using Velacro.Api;
using Velacro.Basic;

using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;

namespace SquareCheck_desktop.SubjectDetail
{
    public class SubjectDetailController : MyController
    {
        public SubjectDetailController(IMyView _myView) : base(_myView)
        {

        }

        public async void getSubjectDetail(int subjectId)
        {
            try
            {
                await ApiGenerator.GetSubjectListSchedule(viewShowSubjectDetail, subjectId);
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void viewShowSubjectDetail(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("showSubjectDetail", _response.getParsedObject<APIResponse<List<ScheduleModel>>>().Data);
            }
        }
    }
}
