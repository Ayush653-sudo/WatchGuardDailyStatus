namespace Calculator.Library
{
    [TestClass]
    public class UnitTest1
    {

        //unit of work state under test expected behaviour
        [TestMethod]
        [TestCategory("Calculator")]
        public void Divide_PositiveNumber_ReturnsPositiveQuotient()
        {
            int expected = 5;
            int numerator = 20;
            int denominator = 4;
            int actual = Calculator.Lib.Program.Divide(numerator, denominator);
            Assert.AreEqual(expected, actual);
           
        }
        [TestMethod]
        [TestCategory("Calculator")]
        public void Divide_PositiveNumeratorAndNegativeDenominator_ReturnsNegativeQuotient()
        {
            int expected = -5;
            int numerator = 20;
            int denominator = -4;
            int actual = Calculator.Lib.Program.Divide(numerator, denominator);
            Assert.AreEqual(expected, actual);

        }

    }
}