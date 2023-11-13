using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Calculator.Lib.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        public TestContext TestContext { get; set; }
        [TestMethod()]
        [TestCategory("Calc")]
        [TestProperty("Test Group","Performance")]
        [Owner("Tomar")]
        [Priority(1)]
        public void DivideTest()
        {

            int expected = -5;
            int numerator = 20;
            int denominator = -4;
            int actual = Calculator.Lib.Program.Divide(numerator, denominator);
            System.Diagnostics.Debug.WriteLine("Debug:Divide Test Executed");
            Assert.AreEqual(expected, actual);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);
            TestContext.WriteLine(TestContext.CurrentTestOutcome.ToString());

          
        }

        
    }
}