using SquareCheck_desktop.Model;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SquareCheck_desktop.SubjectDetail
{
    public class SubjectDetailContext
    {
        ICommand _command;

        public ScheduleModel Schedule { get; set; }

        public ICommand SubjectDetailCommand
        {
            get { return _command; }
        }

        public static List<SubjectDetailContext> FromSchedules(List<ScheduleModel> schedules, Action<ScheduleModel> goToDetailKehadiranMatakuliah)
        {
            var list = new List<SubjectDetailContext>();
            foreach (var summary in schedules)
            {
                var context = new SubjectDetailContext
                {
                    Schedule = summary,
                    _command = new SubjectDetailCommand(goToDetailKehadiranMatakuliah)
                };
                list.Add(context);
            }
            return list;
        }
    }

    public class SubjectDetailCommand : ICommand
    {
        private Action<ScheduleModel> goToDetailKehadiranMatakuliah;

        public SubjectDetailCommand(Action<ScheduleModel> goToDetailKehadiranMatakuliah)
        {
            this.goToDetailKehadiranMatakuliah = goToDetailKehadiranMatakuliah;
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
            goToDetailKehadiranMatakuliah((ScheduleModel)parameter);
        }
    }
}
