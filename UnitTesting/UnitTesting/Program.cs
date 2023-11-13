
namespace Calculator.Lib
{
   public class Program
    {
        public static int Divide(int numerator, int denominator)
        {
            int result = numerator / denominator;
            return result;
        }
        public static void Main()
        {
            Program.Divide(1, 2);
        }
    }
}
