namespace SquareCheck_desktop.Model
{
    public class ScheduleModel
    {
        public int Id { get; set; }
        public SubjectModel Subject { get; set; }
        public string Time { get; set; }
        public string StartTime { get; set; }
        public object EndTime { get; set; }
        public AttendanceModel Attendance { get; set; }
    }
}
