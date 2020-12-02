using SquareCheck_desktop.ListSubject;
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
        }

        private void logout_selected(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() => {
                this.NavigationService.GoBack();
                this.NavigationService.RemoveBackEntry();
            });
        }

        private void matakuliah_selected(object sender, RoutedEventArgs e)
        {
            subPage.Navigate(new ListSubjectPage());
        }

        private void mahasiswa_selected(object sender, RoutedEventArgs e)
        {

        }

        private void home_selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
