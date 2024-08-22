namespace FinalExercise.Data
{
    public class Programme
    {
        public int ProgrammeId { get; set; }
        public string Name { get; set; }

        public ICollection<Course>? Courses { get; set; }
    }
}
