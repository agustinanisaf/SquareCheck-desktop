using SquareCheck_desktop.ListStudentSubjects;
using SquareCheck_desktop.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Velacro.UIElements.Basic;

namespace SquareCheck_desktop.ListMahasiswaJurusan
{
    /// <summary>
    /// Interaction logic for ListMahasiswaJurusanPage.xaml
    /// </summary>
    public partial class ListMahasiswaJurusanPage : MyPage
    {
        public ListMahasiswaJurusanPage(int jurusanId)
        {
            InitializeComponent();
            setController(new ListMahasiswaJurusanController(this));
            getController().callMethod("getData", jurusanId);
        }

        public void showListMahasiswa(List<StudentModel> model)
        {
            this.Dispatcher.Invoke(() =>
            {
                ListMahasiswa.ItemsSource = model;
            });
        }

        private void Edit_click(object sender, RoutedEventArgs e)
        {
            try
            {
                StudentModel dataRowView = (StudentModel)((Button)e.Source).DataContext;
                String NRP = dataRowView.Nrp;
                String Name = dataRowView.Name;
                MessageBox.Show("You Clicked : " + NRP + "\r\nName : " + Name);
                //This is the code which will show the button click row data. Thank you.

                // Navigate to Next Page
                this.NavigationService.Navigate(new ListStudentSubjectsPage(dataRowView));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
