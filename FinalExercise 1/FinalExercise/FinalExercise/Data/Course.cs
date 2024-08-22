namespace FinalExercise.Data
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }

        public int ProgrammeId { get; set; }
        public Programme Programme { get; set; }
    }
}
