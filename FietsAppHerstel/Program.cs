namespace FietsAppHerstel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Fiets carbonBike = new Fiets();
            carbonBike.Material = "Carbon";
            carbonBike.Color = "Yellow";
            carbonBike.FrameSize = 45;
            
            Console.WriteLine(carbonBike.ToString());

            // Aluminium, pink, 48
            Fiets aluBike = new Fiets() { Material = "aluminium", Color = "pink", FrameSize = 48 };
            Console.WriteLine(aluBike.ToString());

            // carbon, green, 50
            Fiets carbonGreen = new Fiets("Carbon", "Green", 50);
            Console.WriteLine(carbonGreen.ToString());

            MountainBike mtb = new MountainBike() { FrameSize = 50, Color = "Black", Material = "Plastiek" };
            mtb.Stop();
            Console.WriteLine(mtb.ToString());

            SpeedPedelec ped = new SpeedPedelec() { FrameSize = 50, Color = "Black", Material = "Plastiek" };
            ped.Charge();
            Console.WriteLine(ped.ToString());
        }
    }
}
