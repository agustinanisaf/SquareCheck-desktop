using SquareCheck_desktop.ListMahasiswa;
using SquareCheck_desktop.ListMahasiswaJurusan;
using SquareCheck_desktop.ListSubject;
using SquareCheck_desktop.ListSubjectofDepartment;
using SquareCheck_desktop.Model;
using System.Collections.Generic;
using Velacro.UIElements.Basic;

namespace SquareCheck_desktop.Dashboard
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : MyPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            setController(new DashboardController(this));
            initUIElements();
        }

        private void initUIElements()
        {
            getController().callMethod("GetDashboardData");
        }

        public void ShowListSubject(List<DepartmentSummaryModel> items)
        {
            this.Dispatcher.Invoke(() =>
            {
                icSubjects.ItemsSource = ListSubjectContext.FromDepartmentSummary(items, GoToListSubject);
            });
        }

        public void ShowListStudent(List<DepartmentSummaryModel> items)
        {
            this.Dispatcher.Invoke(() =>
            {
                icStudent.ItemsSource = ListMahasiswaContext.FromDepartmentSummary(items, GoToListStudent);
            });
        }

        public void GoToListSubject(DepartmentSummaryModel department)
        {
            this.Dispatcher.Invoke(() => {
                this.NavigationService.Navigate(new ListSubjectofDepartmentPage(department));
            });
        }

        public void GoToListStudent(int departmentId)
        {
            this.Dispatcher.Invoke(() => {
                this.NavigationService.Navigate(new ListMahasiswaJurusanPage(departmentId));
            });
        }

        private void StudentButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() => {
                this.NavigationService.Navigate(new ListSubjectPage());
            });
        }

        private void SubjectButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() => {
                this.NavigationService.Navigate(new ListMahasiswa.ListMahasiswa());
            });
        }
    }
}
