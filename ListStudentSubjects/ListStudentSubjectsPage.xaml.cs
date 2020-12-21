using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using Velacro.UIElements.Basic;
using SquareCheck_desktop.DetailKehadiranMahasiswa;

namespace SquareCheck_desktop.ListStudentSubjects
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ListStudentSubjectsPage : MyPage
    {
        private StudentModel student;
        public ListStudentSubjectsPage(StudentModel student)
        {
            InitializeComponent();
            this.KeepAlive = true;
            this.student = student;
            setController(new ListStudentSubjectsController(this, student));
            initUIElements();
        }

        private void initUIElements()
        {
            getController().callMethod("getListSubject");
            breadcrumbs.Text += " / " + student.Department.Name + " / " + student.Nrp;
            StudentsName.Text = student.Name;
            StudentsNrp.Text = student.Nrp;
        }

        public void showListSubject(List<SubjectModel> items)
        {
            this.Dispatcher.Invoke(() =>
            {
                icListSubject.ItemsSource = ListStudentSubjectsContext.FromSubjectModel(items, student, GoToListKehadiranMahasiswa);
            });
        }

        public void GoToListKehadiranMahasiswa(StudentSubjectModel subject)
        {
            this.Dispatcher.Invoke(() =>
            {
                NavigationService.Navigate(new DetailKehadiranMahasiswaPage(subject));
            });
        }
    }
}
