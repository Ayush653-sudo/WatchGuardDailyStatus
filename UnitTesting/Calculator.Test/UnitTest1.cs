using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Calculator.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int expected = 5;
            int numerator = 20;
            int denominator = 4;
            int actual= Calculator.Library.Divide(expected,denominator);

        }
    }
}
