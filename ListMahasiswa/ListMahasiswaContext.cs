using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SquareCheck_desktop.ListMahasiswa
{
    class ListMahasiswaContext
    {
        ICommand _command;
        public DepartmentSummaryModel DepartmentSummary { get; set; }

        public ICommand ListMahasiswaCommand
        {
            get { return _command; }
        }

        public static List<ListMahasiswaContext> FromDepartmentSummary(List<DepartmentSummaryModel> departmentSummaries, Action<int> goToListMahasiswaJurusan)
        {
            var list = new List<ListMahasiswaContext>();
            foreach (var summary in departmentSummaries)
            {
                var context = new ListMahasiswaContext();
                context.DepartmentSummary = summary;
                context._command = new ListMahasiswaCommand(goToListMahasiswaJurusan);
                list.Add(context);
            }
            return list;
        }
    }

    public class ListMahasiswaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<int> goToListMahasiswaJurusan;

        public ListMahasiswaCommand(Action<int> goToListMahasiswaJurusan)
        {
            this.goToListMahasiswaJurusan = goToListMahasiswaJurusan;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Change to Other Page
            Console.WriteLine("Go to List MahasiswaJurusan with jurusanId: " + parameter);
            goToListMahasiswaJurusan((int)parameter);
        }
    }
}
