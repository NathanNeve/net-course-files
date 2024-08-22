namespace MyFitnessWebApp.Models
{
    public class Workout
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; } // Muscles
        public int DifficultyLevel { get; set; }
        public bool EquipmentNeeded { get; set; }

        // belongs to 1 Gym
        public Gym Gym { get; set; }
        public long GymId {  get; set; }
    }
}
