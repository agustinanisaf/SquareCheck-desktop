using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using Velacro.UIElements.Basic;

namespace SquareCheck_desktop.ListStudentSubjects
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ListStudentSubjectsPage : MyPage
    {
        public ListStudentSubjectsPage(StudentModel student)
        {
            this.KeepAlive = true;
            setController(new ListStudentSubjectsController(this, student));
            initUIElements();
        }

        private void initUIElements()
        {
            getController().callMethod("getListSubject");
        }

        public void showListSubject(List<ListStudentSubjectsContext> items)
        {
            this.Dispatcher.Invoke(() =>
            {
                icListSubject.ItemsSource = items;
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
    }
}
