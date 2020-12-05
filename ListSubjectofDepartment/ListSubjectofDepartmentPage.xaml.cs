using SquareCheck_desktop.ListSubjectofDepartment;
using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using Velacro.UIElements.Basic;

namespace SquareCheck_desktop.ListSubjectofDepartment
{
    /// <summary>
    /// Interaction logic for ListSubjectofDepartmentPage.xaml
    /// </summary>
    public partial class ListSubjectofDepartmentPage : MyPage
    {
        DepartmentSummaryModel department;

        public ListSubjectofDepartmentPage(DepartmentSummaryModel department)
        {
            InitializeComponent();
            this.KeepAlive = true;
            this.department = department;
            setController(new ListSubjectofDepartmentController(this));
            initUIElements();
        }

        private void initUIElements()
        {
            DepartmentName.Text = department.Name;
            getController().callMethod("getListSubjectofDepartment", department.Id);
        }

        public void showListSubjectofDepartment(List<SubjectModel> subjects)
        {
            this.Dispatcher.Invoke(() =>
            {
                icListSubject.ItemsSource = ListSubjectofDepartmentContext.FromSubject(subjects);
            });
        }
    }
}
