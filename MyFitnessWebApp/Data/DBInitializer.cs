namespace MyFitnessWebApp.Data
{
    public static class DBInitializer
    {
        public static void Initialize(FitnessDbContext context)
        {
            context.Database.EnsureCreated();

            context.Gyms.Add(new Models.Gym()
            {
                Adress = "Dummy",
                FoundDate = new DateTime(2019, 10, 19),
                MaxCapacity = 100,
                Name = "Dikkeschijvenpompen",
            });

            context.SaveChanges();
        }
    }
}
