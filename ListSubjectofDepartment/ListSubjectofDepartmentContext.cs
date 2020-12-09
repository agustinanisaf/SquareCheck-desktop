using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SquareCheck_desktop.ListSubjectofDepartment
{

    public class ListSubjectofDepartmentContext
    {
        ICommand _command;
        
        public SubjectModel Subject { get; set; }

        public ICommand ListSubjectofDepartmentCommand
        {
            get { return _command; }
        }

        public static List<ListSubjectofDepartmentContext> FromSubject(List<SubjectModel> subjectofDepartment, Action<SubjectModel> goToSubjectDetail)
        {
            var list = new List<ListSubjectofDepartmentContext>();
            foreach(var summary in subjectofDepartment)
            {
                var context = new ListSubjectofDepartmentContext
                {
                    Subject = summary,
                    _command = new ListSubjectofDepartmentCommand(goToSubjectDetail)
                };
                list.Add(context);
            }
            return list;
        }
    }

    public class ListSubjectofDepartmentCommand : ICommand
    {
        private Action<SubjectModel> goToSubjectDetail;

        public ListSubjectofDepartmentCommand(Action<SubjectModel> goToSubjectDetail)
        {
            this.goToSubjectDetail = goToSubjectDetail;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Change to Other Page
            Console.WriteLine(parameter);
            goToSubjectDetail((SubjectModel)parameter);
        }
    }
}
