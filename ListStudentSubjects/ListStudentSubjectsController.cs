﻿using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Velacro.Api;
using Velacro.Basic;

namespace SquareCheck_desktop.ListStudentSubjects
{
    public class ListStudentSubjectsController : MyController
    {
        StudentModel Student;
        public ListStudentSubjectsController(IMyView _myView, StudentModel student) : base(_myView)
        {
            this.Student = student;
        }

        public async void getListSubject()
        {
            try
            {
                await ApiGenerator.GetStudentListSubject(viewShowListSubject, Student.Id);
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void viewShowListSubject(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                List<SubjectModel> dataSubject = _response.getParsedObject<APIResponse<List<SubjectModel>>>().Data;
                Console.WriteLine(_response);
                getView().callMethod("showListSubject", dataSubject);
            }
        }
    }
}