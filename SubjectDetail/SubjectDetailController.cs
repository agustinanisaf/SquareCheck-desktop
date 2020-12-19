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
                List<ScheduleModel> model = _response.getParsedObject<APIResponse<List<ScheduleModel>>>().Data;
                List<ScheduleModel> result = new List<ScheduleModel>();
                DateTime date;

                foreach (var key in model)
                {
                    date = Convert.ToDateTime(key.Time);
                    key.Time = date.ToString("dddd, dd MMM yyyy");
                    result.Add(key);
                }
                getView().callMethod("showSubjectDetail", result);
            }
        }
    }
}
