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
using SquareCheck_desktop.Model;

namespace SquareCheck_desktop.EditAbsensi
{
    /// <summary>
    /// Interaction logic for EditAbsensi.xaml
    /// </summary>
    public partial class EditAbsensi : MyPage
    {
        public EditAbsensi()
        {
            InitializeComponent();
            this.KeepAlive = true;
            setController(new EditAbsensiController(this));
            initUIElements();
        }

        private void initUIElements()
        {
            getController().callMethod("getStudentAttendance");
        }

        public void showStudentAttendance(List<AttendanceModel> items)
        {
            this.Dispatcher.Invoke(() => 
            {
                icStudentAttendance.ItemsSource = items;
            });
        }
    }
}
