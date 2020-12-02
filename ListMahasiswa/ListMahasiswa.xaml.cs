using SquareCheck_desktop.Model;
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
                icListMahasiswa.ItemsSource = ListMahasiswaContext.FromDepartmentSummary(items);
            });
        }
    }
}
