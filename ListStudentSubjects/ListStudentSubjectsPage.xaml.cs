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
            this.KeepAlive = true;
            this.student = student;
            setController(new ListStudentSubjectsController(this, student));
            initUIElements();
        }

        private void initUIElements()
        {
            getController().callMethod("getListSubject");
        }

        public void showListSubject(List<SubjectModel> items)
        {
            this.Dispatcher.Invoke(() =>
            {
                icListSubject.ItemsSource = ListStudentSubjectsContext.FromSubjectModel(items, student, GoToListKehadiranMahasiswa);
            });
        }

        public void showStudentProfile(StudentModel student)
        {
            this.Dispatcher.Invoke(() =>
            {
                StudentsName.Text = student.Name;
                StudentsNrp.Text = student.Nrp;

            });
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            InitializeComponent();
            getController().callMethod("viewShowStudentsProfile");
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
