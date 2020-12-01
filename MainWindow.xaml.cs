using Velacro.UIElements.Basic;
using SquareCheck_desktop.Private;
using System;

namespace SquareCheck_desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MyWindow
    {
        private MyPage loginPage, privatePage;

        public MainWindow()
        {
            InitializeComponent();
            privatePage = new PrivatePage(GoToLoginPage);
            GoToPrivatePage();
        }

        public void GoToPrivatePage()
        {
            mainFrame.Navigate(privatePage);
        }

        public void GoToLoginPage()
        {
            mainFrame.Navigate(loginPage);
        }
    }
}
