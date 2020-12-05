using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SquareCheck_desktop.ListSubject
{
    

    public class ListSubjectContext
    {
        ICommand _command;
        public DepartmentSummaryModel DepartmentSummary { get; set; }

        public ICommand ListSubjectCommand
        {
            get { return _command; }
        }

        public static List<ListSubjectContext> FromDepartmentSummary(List<DepartmentSummaryModel> departmentSummaries, Action<DepartmentSummaryModel> goToListSubjectofDepartment)
        {
            var list = new List<ListSubjectContext>();
            foreach(var summary in departmentSummaries)
            {
                var context = new ListSubjectContext();
                context.DepartmentSummary = summary;
                context._command = new ListSubjectCommand(goToListSubjectofDepartment);
                list.Add(context);
            }
            return list;
        }
    }

    public class ListSubjectCommand : ICommand
    {
        private Action<DepartmentSummaryModel> goToListSubjectofDepartment;

        public event EventHandler CanExecuteChanged;
        
        public ListSubjectCommand(Action<DepartmentSummaryModel> goToListSubjectofDepartment)
        {
            this.goToListSubjectofDepartment = goToListSubjectofDepartment;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Change to Other Page
            Console.WriteLine(parameter);
            goToListSubjectofDepartment((DepartmentSummaryModel)parameter);
        }
    }
}
