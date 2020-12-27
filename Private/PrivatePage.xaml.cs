using SquareCheck_desktop.Dashboard;
using SquareCheck_desktop.ListSubject;
using SquareCheck_desktop.Model;
using System.Windows;
using Velacro.UIElements.Basic;

namespace SquareCheck_desktop.Private
{
    /// <summary>
    /// Interaction logic for PrivatePage.xaml
    /// </summary>
    public partial class PrivatePage : MyPage
    {
        public PrivatePage()
        {
            InitializeComponent();
            this.KeepAlive = true;
            setController(new PrivatePageController(this));
            subPage.Navigate(new DashboardPage());
            getController().callMethod("getUserData");
        }

        private void logout_selected(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.NavigationService.Navigate(new Login.LoginPage());
                this.NavigationService.RemoveBackEntry();
            });
        }

        private void matakuliah_selected(object sender, RoutedEventArgs e)
        {
            subPage.Navigate(new ListSubjectPage());
        }

        private void mahasiswa_selected(object sender, RoutedEventArgs e)
        {
            subPage.Navigate(new ListMahasiswa.ListMahasiswa());
        }

        private void home_selected(object sender, RoutedEventArgs e)
        {
            subPage.Navigate(new DashboardPage());
        }

        public void showInfoUser(UserModel model)
        {
            this.Dispatcher.Invoke(() =>
            {
                username.Text = model.Email;
            });
        }
    }
}
