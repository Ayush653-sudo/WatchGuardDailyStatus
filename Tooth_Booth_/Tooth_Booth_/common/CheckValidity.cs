
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



    }
}
