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
        public void IsValidEmail_InValidEmailInput_False()
        {
            string sampleInValidString = "ayushsing@gmail";
            string regex = CheckValidity.emailRegex;
            bool expected= false;
            bool actual = CheckValidity.IsValidEmail(sampleInValidString);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidEmail_ValidEmailInput_true()
        {
            string sampleValidString = "ayushsing@gmail.com";
            string regex = CheckValidity.emailRegex;
            bool expected = true;
            bool actual = CheckValidity.IsValidEmail(sampleValidString);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidPhoneNumber_ValidPhoneInput_true()
        {
            string sampleInValidString = "9636653732";
            bool expected = true;
            bool actual = CheckValidity.IsValidPhoneNumber(sampleInValidString);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidPhoneNumber_InValidPhoneInput_false()
        {
            string sampleInValidString = "96366537";
            bool expected = false;
            bool actual = CheckValidity.IsValidPhoneNumber(sampleInValidString);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsUserNameNotValid_ValidUserNameInput_false()
        {
            string sampleValidString = "ayush22";
            bool expected = false;
            bool actual = CheckValidity.IsUserNameNotValid(sampleValidString);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsUserNameNotValid_InValidUserNameInput_true()
        {
            string sampleInValidString = " ";
            bool expected = true;
            bool actual = CheckValidity.IsUserNameNotValid(sampleInValidString);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
 
        public void CheckRegex_ValidOnlyAlphabet_true()
        {
            string sampleInValidString = "AaA";
            string regex = CheckValidity.hasOnlyAlphabet;
            bool expected = true;
            bool actual = CheckValidity.CheckRegex(sampleInValidString, regex);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckRegex_InValidOnlyAlphabet_true()
        {
            string sampleInValidString = "Aa2A";
            string regex = CheckValidity.hasOnlyAlphabet;
            bool expected = false;
            bool actual = CheckValidity.CheckRegex(sampleInValidString, regex);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidPassword_InValidPassword_false()
        {
            string sampleInValidString = "Aa2A";
            bool expected = false;
            bool actual = CheckValidity.IsValidPassword(sampleInValidString);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidPassword_ValidPassword_true()
        {
            string sampleValidString = "Ayus@223";
            bool expected = true;
            bool actual = CheckValidity.IsValidPassword(sampleValidString);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNotValidClinicName_ValidClinicName_false()
        {
            string sampleValidString = "RoomShoom";
            bool expected = false;
            bool actual=CheckValidity.IsNotValidClinicName(sampleValidString);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNotValidClinicName_InValidClinicName_false()
        {
            string sampleInValidString = "";
            bool expected = true;
            bool actual = CheckValidity.IsNotValidClinicName(sampleInValidString);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsNotValidClinicCity_ValidClinicCity_false()
        {
            string sampleValidString = "Rawatbhata";
            bool expected = false;
            bool actual = CheckValidity.IsNotValidClinicCity(sampleValidString);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsNotValidClinicCity_InValidClinicCity_true()
        {
            string sampleValidString = "Ra";
            bool expected = true;
            bool actual = CheckValidity.IsNotValidClinicCity(sampleValidString);
            Assert.AreEqual(expected, actual);
        }


    }
}
