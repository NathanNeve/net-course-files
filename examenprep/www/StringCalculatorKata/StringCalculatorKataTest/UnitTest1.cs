using StringCalculatorKata;

namespace StringCalculatorKataTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_EmptyStringAsParam_ReturnsZero()
        {
            // arr & act
            int value = StringCalculator.Add("");

            // assert
            Assert.AreEqual(value, 0);
        }

        [TestMethod]
        public void Add_StringContainingSingleNumber_ReturnsTheNumberItself()
        {
            // arr & act
            int value = StringCalculator.Add("1");

            // assert
            Assert.AreEqual(value, 1);
        }

        [TestMethod]
        public void TwoNumbersSeparatedByComma_ReturnsTheirSum()
        {
            int value = StringCalculator.Add("1,2");
            Assert.AreEqual(value, 3);
        }

        [DataTestMethod]
        [DataRow("1,2,3", 6)]
        [DataRow("1,2,3,4", 10)]
        [DataRow("1,2,3,4,5", 15)]
        public void MoreThanThreeNumbersSeparatedByComma_ReturnsTheirSum(string numbers, int result)
        {
            int value = StringCalculator.Add(numbers);
            Assert.AreEqual(value, result);
        }

        [DataTestMethod]
        [DataRow("1,2,3", 6)]
        [DataRow("1,2,3,4,1001", 10)]
        public void NumbersSeparatedByCommaWithMoreThan1000_ReturnsTheirSumWithLargerThan1000Exluded(string numbers, int result)
        {
            int value = StringCalculator.Add(numbers);
            Assert.AreEqual(value, result);
        }

        [DataTestMethod]
        [DataRow("1,2,3,4,1001,-1", 10)]    
        [DataRow("1,2,-3,4,-1001,-1", 10)]
        public void StringContainingNegativeNumbers_ThrowsException(string numbers, int result)
        {
            Action action = () => StringCalculator.Add(numbers);
            Assert.ThrowsException<Exception>(action);
        }

    }
}
