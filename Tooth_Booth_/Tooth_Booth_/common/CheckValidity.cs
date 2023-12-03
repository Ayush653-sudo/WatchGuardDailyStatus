
using System.Text.RegularExpressions;


namespace Tooth_Booth_.common
{
  public class CheckValidity
    {


        public static string hasnumber = @"^([0]|\+91)?[789]\d{9}$";
        public static string hNumber = @"[0-9]+";
        public static string hasUpperChar = @"[A-Z]+";
        public static string hasMinimum5Chars = @".{5,}";
        public static string hasSymbols = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";
        public static string emailRegex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
        public static string hasOnlyAlphaNumeric = @"^[a-zA-Z][a-zA-Z0-9]*$";
        public static string hasOnlyAlphabet = @"^[a-zA-Z]+$";

        public static bool NullCheck(String s)
        {
            if (String.IsNullOrEmpty(s))
                return true;
            else
                return false;
        }

        public static bool IsNotValidLength(string s, int length)
        {
            if (s.Length < length)
                return true;
            else
                return false;

        }
        
        public static bool IsValidCountWords(String s,int max)
        {
            if (s.Split(" ").Count() > max)
                return true;
            else
                return false;
        }
        public static bool CheckRegex(String str,String regexString)
        {

            return Regex.IsMatch(str, regexString, RegexOptions.IgnoreCase);

        }
        public static bool IsUserNameNotValid(string userName)
        {
            return CheckValidity.NullCheck(userName) || CheckValidity.IsNotValidLength(userName, 5) || !CheckValidity.CheckRegex(userName, CheckValidity.hasOnlyAlphaNumeric);
        }
        public static bool IsValidPassword(String password)
        {
            return CheckValidity.CheckRegex(password, CheckValidity.hNumber) && CheckValidity.CheckRegex(password, CheckValidity.hasUpperChar) && CheckValidity.CheckRegex(password, CheckValidity.hasMinimum5Chars) && CheckValidity.CheckRegex(password, CheckValidity.hasSymbols);
        }

        public static bool IsValidEmail(string emailAddress)
        {
           return CheckValidity.CheckRegex(emailAddress, CheckValidity.emailRegex);
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            return CheckValidity.CheckRegex(phoneNumber, CheckValidity.hasnumber); 
        }
        public static bool IsNotValidClinicName(string clinicName)
        {
            return CheckValidity.IsNotValidLength(clinicName, 6) || CheckValidity.NullCheck(clinicName);
        }
        public static bool IsNotValidClinicCity(string clinicCity)
        {
            return CheckValidity.NullCheck(clinicCity) || !CheckValidity.CheckRegex(clinicCity, CheckValidity.hasOnlyAlphabet) || CheckValidity.IsNotValidLength(clinicCity, 3);
        }



    }
}
