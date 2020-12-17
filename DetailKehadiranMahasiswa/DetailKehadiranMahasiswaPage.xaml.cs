using SquareCheck_desktop.DetailKehadiranMahasiswa;
using SquareCheck_desktop.ListStudentSubjects;
using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Velacro.Api;
using Velacro.UIElements.Basic;
using Velacro.UIElements.Button;


namespace SquareCheck_desktop.DetailKehadiranMahasiswa
{
    /// <summary>
    /// Interaction logic for DetailKehadiranMahasiswaPage.xaml
    /// </summary>
    public partial class DetailKehadiranMahasiswaPage : MyPage
    {
        private BuilderButton buttonBuilder;
        private IMyButton loginButton;

        public DetailKehadiranMahasiswaPage(StudentSubjectModel studentSubjectModel)
        {
            InitializeComponent();
            setController(new DetailKehadiranMahasiswaController(this));
            initUIBuilders();
            initUIElements(studentSubjectModel.Student.Id, studentSubjectModel.Subject.Id);
            StudentName.Text = studentSubjectModel.Student.Name;
            StudentNRP.Text = studentSubjectModel.Student.Nrp;
            SubjectName.Text = studentSubjectModel.Subject.Name;
            Breadcrumbs.Text = "Mahasiswa " + " / " + studentSubjectModel.Student.Department.Name
                + " / " + studentSubjectModel.Student.Name + " / "
                + studentSubjectModel.Subject.Name;
        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
        }

        private void initUIElements(int studentId, int studentSubjectId)
        {
            getController().callMethod("getListDetailKehadiranMahasiswa", studentId, studentSubjectId);
        }

        public void showListDetailKehadiranMahasiswa(List<ScheduleModel> model)
        {
            this.Dispatcher.Invoke(() =>
            {
                Console.WriteLine(model);
                if (0 != model.Count)
                {
                    Message_text.Visibility = Visibility.Collapsed;
                    ListSchedule.ItemsSource = model;
                }
                else
                {
                    ListSchedule.Visibility = Visibility.Collapsed;
                }
            });
        }
    }
}
