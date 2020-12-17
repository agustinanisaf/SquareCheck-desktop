using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SquareCheck_desktop.ListStudentSubjects
{


    public class ListStudentSubjectsContext
    {
        ICommand _command;
        StudentSubjectModel __studentSubject = new StudentSubjectModel();

        public ICommand ListStudentSubjectsCommand
        {
            get { return _command; }
        }
        public StudentSubjectModel StudentSubject
        {
            get { return __studentSubject; }
        }

        public static List<ListStudentSubjectsContext> FromSubjectModel(List<SubjectModel> listSubject, StudentModel student, Action<StudentSubjectModel> goToListDetailKehadiranMhs)
        {
            var list = new List<ListStudentSubjectsContext>();
            foreach (var subject in listSubject)
            {
                var context = new ListStudentSubjectsContext();
                context.StudentSubject.Subject = subject;
                context.StudentSubject.Student = student;
                context._command = new ListStudentSubjectsCommand(goToListDetailKehadiranMhs);
                list.Add(context);
            }
            return list;
        }
    }

    public class ListStudentSubjectsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<StudentSubjectModel> goToListDetailKehadiranMhs;

        public ListStudentSubjectsCommand(Action<StudentSubjectModel> goToListDetailKehadiranMhs)
        {
            this.goToListDetailKehadiranMhs = goToListDetailKehadiranMhs;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //TODO: Use parameter to Change to Detail Absensi Page(parameter is StudentSubjectModel)
            Console.WriteLine(parameter);
            goToListDetailKehadiranMhs((StudentSubjectModel)parameter);
        }
    }
}
