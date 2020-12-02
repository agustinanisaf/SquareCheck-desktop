using SquareCheck_desktop.Model;
using System.Collections.Generic;
using Velacro.UIElements.Basic;

namespace SquareCheck_desktop.ListSubject
{
    /// <summary>
    /// Interaction logic for ListSubjectPage.xaml
    /// </summary>
    public partial class ListSubjectPage : MyPage
    {
        public ListSubjectPage()
        {
            InitializeComponent();
            this.KeepAlive = true;
            setController(new ListSubjectController(this));
            initUIElements();
        }

        private void initUIElements()
        {
            getController().callMethod("getListSubject");
        }

        public void showListSubject(List<DepartmentSummaryModel> items)
        {
            this.Dispatcher.Invoke(() =>
            {
                icListSubject.ItemsSource = ListSubjectContext.FromDepartmentSummary(items);
            });
        }
    }
}
