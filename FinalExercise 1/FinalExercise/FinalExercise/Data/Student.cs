namespace FinalExercise.Data
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { 
            get
            {
                return $"{FirstName} {LastName}";
            } 
        }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
