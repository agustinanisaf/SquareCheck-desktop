using SquareCheck_desktop.ListMahasiswaJurusan;
using SquareCheck_desktop.Model;
using System.Collections.Generic;
using Velacro.UIElements.Basic;

namespace SquareCheck_desktop.ListMahasiswa
{
    /// <summary>
    /// Interaction logic for ListMahasiswa.xaml
    /// </summary>
    public partial class ListMahasiswa : MyPage
    {
        public ListMahasiswa()
        {
            InitializeComponent();
            this.KeepAlive = true;
            setController(new ListMahasiswaController(this));
            initUIElements();
        }

        private void initUIElements()
        {
            getController().callMethod("getListMahasiswa");
        }

        public void showListMahasiswa(List<DepartmentSummaryModel> items)
        {
            this.Dispatcher.Invoke(() =>
            {
                icListMahasiswa.ItemsSource = ListMahasiswaContext.FromDepartmentSummary(items, GoToListMahasiswaJurusan);
            });
        }

        public void GoToListMahasiswaJurusan(int jurusanId)
        {
            this.Dispatcher.Invoke(() => {
                NavigationService.Navigate(new ListMahasiswaJurusanPage(jurusanId));
            });
        }
    }
}
