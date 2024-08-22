namespace Adventures.Web.Helpers
{
    public class TravelHelper
    {
        public enum TravelType
        {
            walking_vacation,
            safari,
            self_drive
        }

        public class TravelTypeNotFound : ApplicationException 
        { 
        }

        public static TravelType GetTravelType(string description)
        {
            if (description.Contains("trail"))
            {
                return TravelType.walking_vacation;
            }
            if (description.Contains("game"))
            {
                return TravelType.safari;
            }
            if (description.Contains("road trip"))
            {
                return TravelType.self_drive;
            }
            throw new TravelTypeNotFound();
        }
    }
}
