using SquareCheck_desktop.DetailKehadiranMahasiswa;
using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using Velacro.Api;
using Velacro.UIElements.Basic;


namespace SquareCheck_desktop.DetailKehadiranMahasiswa
{
    /// <summary>
    /// Interaction logic for DetailKehadiranMahasiswaPage.xaml
    /// </summary>
    public partial class DetailKehadiranMahasiswaPage : MyPage
    {
        public DetailKehadiranMahasiswaPage()
        {
            InitializeComponent();
            setController(new DetailKehadiranMahasiswaController(this));
            getController().callMethod("getListDetailKehadiranMahasiswa", 2);
        }

        private void initUIElements()
        {
            getController().callMethod("getListDetailKehadiranMahasiswa");
        }

        public void showListDetailKehadiranMahasiswa(List<SubjectModel> subjects)
        {
            this.Dispatcher.Invoke(() =>
            {
                icListDetailKehadiranMahasiswa.ItemsSource = DetailKehadiranMahasiswaContext.FromSubject(subjects);
            });
        }
    }
}
