namespace MyFitnessWebApp.Models
{
    public class Gym
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public string Adress { get; set; }
        public DateTime FoundDate { get; set; }

        // one or more equipment
        public List<Workout> Workouts { get; set; }
    }
}
