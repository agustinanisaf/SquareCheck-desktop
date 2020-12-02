using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Velacro.Basic;
using Velacro.UIElements.Basic;
using Velacro.UIElements.Button;
using Velacro.UIElements.TextBlock;
using Velacro.UIElements.TextBox;
using Velacro.UIElements.PasswordBox;
using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;
using Velacro.Api;
using System.Net.Http;
using SquareCheck_desktop.Private;

namespace SquareCheck_desktop.Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : MyPage
    {
        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private BuilderPasswordBox passBoxBuilder;
        private IMyButton loginButton;
        private IMyTextBox emailTxtBox;
        private IMyPasswordBox passwordBox;

        public LoginPage()
        {
            InitializeComponent();
            setController(new LoginController(this));
            initUIBuilders();
            initUIElements();
        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            txtBoxBuilder = new BuilderTextBox();
            passBoxBuilder = new BuilderPasswordBox();
        }

        private void initUIElements()
        {
            emailTxtBox = txtBoxBuilder.activate(this, "email_tf");
            passwordBox = passBoxBuilder.activate(this, "password_tf");
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            getController().callMethod("Login", email_tf.Text.ToString(), password_tf.Password.ToString());
        }

        public void ShowLoginSuccess()
        {
            this.Dispatcher.Invoke(() => this.NavigationService.Navigate(new PrivatePage()));
        }
    }
}
