using Adventures.Web.Helpers;
using static Adventures.Web.Helpers.TravelHelper;

namespace Adventures.Tests
{
    [TestClass]
    public class TravelHelperTest
    {
        [DataTestMethod]
        [DataRow("We do a game drive every day.", TravelType.safari)]
        [DataRow("We hike all the trails in the area.", TravelType.walking_vacation)]
        [DataRow("A fantastic road trip through the USA.", TravelType.self_drive)]
        public void ThreeInputs_ReturnTheirCorrespondingType(string input, int result)
        {
            TravelType value = TravelHelper.GetTravelType(input);
            Assert.AreEqual(value, result);
        }


    }
}