using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Velacro.UIElements.Basic;

namespace SquareCheck_desktop.DetailKehadiranMatakuliah
{
    /// <summary>
    /// Interaction logic for DetailKehadiranMatakuliahPage.xaml
    /// </summary>
    public partial class DetailKehadiranMatakuliahPage : MyPage
    {
        private ScheduleModel schedule;

        public DetailKehadiranMatakuliahPage(ScheduleModel schedule)
        {
            InitializeComponent();
            setController(new DetailKehadiranMatakuliahController(this));
            this.schedule = schedule;
            ClassSlug.Text = schedule.Subject.Classroom.Slug;
            Subject.Text = schedule.Subject.Name;
            DateSchedule.Text = schedule.Time.ToString();
            Breadcrumbs.Text += " / " + schedule.Subject.Name + " / " + schedule.Subject.Classroom.Slug + " / " + schedule.Time.ToString();
        }



        public void showListMahasiswa(List<AttendanceModel> model)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (0 != model.Count)
                {
                    Message_text.Visibility = Visibility.Collapsed;
                    ListMahasiswa.ItemsSource = model;
                }
                else
                {
                    ListMahasiswa.Visibility = Visibility.Collapsed;
                }
            });
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AttendanceModel row = (AttendanceModel)((Button)e.Source).DataContext;
            this.NavigationService.Navigate(new EditAbsensi.EditAbsensi(this.schedule, row));
        }

        private void MyPage_Loaded(object sender, RoutedEventArgs e)
        {
            getController().callMethod("getData", schedule.Id);
        }
    }
}
