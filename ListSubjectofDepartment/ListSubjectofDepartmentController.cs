using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Velacro.Api;
using Velacro.Basic;

namespace SquareCheck_desktop.ListSubjectofDepartment
{
    public class ListSubjectofDepartmentController  :  MyController
    {
        public ListSubjectofDepartmentController(IMyView _myView) : base(_myView)
        {

        }

        public async void getListSubjectofDepartment(int departmentId)
        {
            try
            {
                await ApiGenerator.GetDepartmentListSubject(viewShowListSubjectofDepartment, departmentId);
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void viewShowListSubjectofDepartment(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                getView().callMethod("showListSubjectofDepartment", _response.getParsedObject<APIResponse<List<SubjectModel>>>().Data);
            }
        }
    }
}
