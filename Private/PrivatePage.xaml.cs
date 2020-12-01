using System;
using System.Windows;
using Velacro.UIElements.Basic;

namespace SquareCheck_desktop.Private
{
    /// <summary>
    /// Interaction logic for PrivatePage.xaml
    /// </summary>
    public partial class PrivatePage : MyPage
    {
        public Action GoToLoginPage { get; }

        public PrivatePage(Action goToLoginPage)
        {
            InitializeComponent();
            this.KeepAlive = true;
            GoToLoginPage = goToLoginPage;
        }

        private void logout_selected(object sender, RoutedEventArgs e)
        {
            GoToLoginPage();
        }

        private void matakuliah_selected(object sender, RoutedEventArgs e)
        {

        }

        private void mahasiswa_selected(object sender, RoutedEventArgs e)
        {

        }

        private void home_selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
