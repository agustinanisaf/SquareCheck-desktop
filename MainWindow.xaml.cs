using Velacro.UIElements.Basic;
using SquareCheck_desktop.Private;
using SquareCheck_desktop.Login;
using SquareCheck_desktop.EditAbsensi;

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
            MyPage edit = new EditAbsensi.EditAbsensi();
            mainFrame.Navigate(edit);
        }

        public void GoToPrivatePage()
        {
            privatePage = new PrivatePage();
            mainFrame.Navigate(privatePage);
        }

        public void GoToLoginPage()
        {
            loginPage = new LoginPage();
            mainFrame.Navigate(loginPage);
        }
    }
}
