namespace SquareCheck_desktop.Model
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nrp { get; set; }
        public DepartmentModel Department { get; set; }
        public ClassroomModel Classroom { get; set; }
        public UserModel User { get; set; }
    }
}