using SquareCheck_desktop.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SquareCheck_desktop.ListSubjectofDepartment
{

    public class ListSubjectofDepartmentContext
    {
        ICommand _command = new ListSubjectofDepartmentCommand();
        
        public SubjectModel Subject { get; set; }

        public ICommand ListSubjectofDepartmentCommand
        {
            get { return _command; }
        }

        public static List<ListSubjectofDepartmentContext> FromSubject(List<SubjectModel> subjectofDepartment)
        {
            var list = new List<ListSubjectofDepartmentContext>();
            foreach(var summary in subjectofDepartment)
            {
                var context = new ListSubjectofDepartmentContext();
                context.Subject = summary;
                list.Add(context);
            }
            return list;
        }
    }

    public class ListSubjectofDepartmentCommand : ICommand
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
