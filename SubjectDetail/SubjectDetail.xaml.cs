using System.Collections.Generic;
using Velacro.UIElements.Basic;
using SquareCheck_desktop.Model;
using SquareCheck_desktop.DetailKehadiranMatakuliah;

namespace SquareCheck_desktop.SubjectDetail
{
    /// <summary>
    /// Interaction logic for SubjectDetail.xaml
    /// </summary>
    public partial class SubjectDetail : MyPage
    {
        private readonly SubjectModel subject;

        public SubjectDetail(SubjectModel subject)
        {
            InitializeComponent();
            this.KeepAlive = true;
            this.subject = subject;
            setController(new SubjectDetailController(this));
            initUIElements();
        }

        private void initUIElements()
        {
            DataContext = subject;
            getController().callMethod("getSubjectDetail", subject.Id);
        }

        public void showSubjectDetail(List<ScheduleModel> items)
        {
            this.Dispatcher.Invoke(() =>
            {
                icSubjectDetail.ItemsSource = SubjectDetailContext.FromSchedules(items, GoToDetailKehadiranMatakuliah);
            });
        }

        public void GoToDetailKehadiranMatakuliah(ScheduleModel schedule)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.NavigationService.Navigate(new DetailKehadiranMatakuliahPage(schedule));
            });
        }
    }
}
