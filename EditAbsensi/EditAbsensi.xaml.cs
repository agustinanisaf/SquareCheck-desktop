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
using Velacro.UIElements.ComboBox;
using SquareCheck_desktop.Api;
using SquareCheck_desktop.Model;
using Velacro.Api;
using System.Net.Http;
using SquareCheck_desktop.Private;

namespace SquareCheck_desktop.EditAbsensi
{
    /// <summary>
    /// Interaction logic for EditAbsensi.xaml
    /// </summary>
    public partial class EditAbsensi : MyPage
    {
        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private BuilderComboBox cmbBoxBuilder;
        private IMyButton saveButton;
        private IMyTextBox mhsTxtBox;
        private IMyTextBox jadwalTxtBox;
        private IMyTextBox tglTxtBox;
        private IMyComboBox statusCmbBox;
        private readonly ScheduleModel schedule;
        private readonly AttendanceModel attendance;

        public EditAbsensi(ScheduleModel schedule, AttendanceModel attendance)
        {
            InitializeComponent();
            this.schedule = schedule;
            this.attendance = attendance;
            setController(new EditAbsensiController(this));
            initUIBuilders();
            initUIElements();
        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            txtBoxBuilder = new BuilderTextBox();
            cmbBoxBuilder = new BuilderComboBox();
        }

        private void initUIElements()
        {
            mhsTxtBox = txtBoxBuilder.activate(this, "textBoxMahasiswa");
            jadwalTxtBox = txtBoxBuilder.activate(this, "textBoxJadwal");
            tglTxtBox = txtBoxBuilder.activate(this, "textBoxTanggal");
            statusCmbBox = cmbBoxBuilder.activate(this, "comboBoxStatus");
            mhsTxtBox.setText(attendance.Student.Nrp + " - " + attendance.Student.Name);
            jadwalTxtBox.setText(schedule.Subject.Id + " - " + schedule.Subject.Name);
            tglTxtBox.setText(schedule.Id + " - " + schedule.Time);
            statusCmbBox.setSelectedItemIndex(GetStatus(attendance.Status));
            statusCmbBox.addOnSelectionChanged(this, "ChangeAttendanceStatus");
        }

        private int GetStatus(string status)
        {
            switch(status)
            {
                case "hadir":
                    return 0;
                case "terlambat":
                    return 1;
                case "izin":
                    return 2;
                default:
                    return 3;
            }
        }

        private void saveButton_clicked(object sender, RoutedEventArgs e)
        {
            getController().callMethod("update", schedule, attendance);
        }

        public void showUpdateSuccess()
        {
            this.Dispatcher.Invoke(() => {
                this.NavigationService.GoBack();
                this.NavigationService.RemoveBackEntry();
            });
        }

        public void ChangeAttendanceStatus(object sender)
        {
            attendance.Status = ((ComboBoxItem)sender).Content.ToString();
        }
    }
}
