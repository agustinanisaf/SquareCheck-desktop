

using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Velacro.Api;
using Velacro.Basic;

namespace SquareCheck_desktop.ListSubject
{
    public class ListSubjectController  :  MyController
    {
        public ListSubjectController(IMyView _myView) : base(_myView)
        {

        }

        public async void getListSubject()
        {            
            try {
                await ApiGenerator.GetListSubject(viewShowListSubject);
            } catch (HttpRequestException exception) {
                Console.WriteLine(exception.Message);
            }
        }

        private void viewShowListSubject(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("showListSubject", _response.getParsedObject<APIResponse<List<DepartmentSummaryModel>>>().Data);
            }
        }
    }
}
