namespace SquareCheck_desktop.Model
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LecturerModel Lecturer { get; set; }
        public ClassroomModel Classroom { get; set; }
    }
}
