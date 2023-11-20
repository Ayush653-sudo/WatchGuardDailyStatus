using Tooth_Booth_.common;

namespace Tooth_Booth_.test.Common.test
{
    [TestClass]
    public class CheckValidityTest
    {

        [TestMethod]
        public void NullCheck_NotNullInputString_false()
        {
            bool expected = false;
            bool actual=CheckValidity.NullCheck("Argument");
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void NullCheck_NullInputString_True()
        {
            bool expected = true;
            bool actual = CheckValidity.NullCheck(null);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void IsNotValidLengthLength_ValidLength_false()
        {
            string parameter = "CheckingLength";
            int minLength = 5;
            bool expected = false;
            bool actual = CheckValidity.IsNotValidLength(parameter, minLength);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNotValidLengthLength_InValidLength_True()
        {
            string parameter = "Checking";
            int minLength = 9;
            bool expected = true;
            bool actual = CheckValidity.IsNotValidLength(parameter, minLength);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void IsValidCountWord_ValidCountOfWord_True()
        {
            string argument = "Check Me";
            bool expected=true;
            int minCount = 1;
            bool actual=CheckValidity.IsValidCountWords(argument, minCount);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void IsValidCountWord_InValidCountOfWord_False()
        {
            string argument = "Check Me";
            bool expected = false;
            int minCount = 3;
            bool actual = CheckValidity.IsValidCountWords(argument, minCount);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckRegex_InValidInput_False()
        {
            string sampleInValidString = "ayushsing@gmail";
            string regex = CheckValidity.emailRegex;
            bool expected= false;
            bool actual = CheckValidity.CheckRegex(sampleInValidString, regex);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckRegex_ValidInput_true()
        {
            string sampleInValidString = "ayushsing@gmail.com";
            string regex = CheckValidity.emailRegex;
            bool expected = true;
            bool actual = CheckValidity.CheckRegex(sampleInValidString, regex);
            Assert.AreEqual(expected, actual);
        }



    }
}
