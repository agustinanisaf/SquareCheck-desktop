using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SquareCheck_desktop.ListMahasiswa
{
    class ListMahasiswaContext
    {
        ICommand _command = new ListMahasiswaCommand();
        public DepartmentSummaryModel DepartmentSummary { get; set; }

        public ICommand ListMahasiswaCommand
        {
            get { return _command; }
        }

        public static List<ListMahasiswaContext> FromDepartmentSummary(List<DepartmentSummaryModel> departmentSummaries)
        {
            var list = new List<ListMahasiswaContext>();
            foreach (var summary in departmentSummaries)
            {
                var context = new ListMahasiswaContext();
                context.DepartmentSummary = summary;
                list.Add(context);
            }
            return list;
        }
    }

    public class ListMahasiswaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Change to Other Page
            Console.WriteLine(parameter);
        }
    }
}
