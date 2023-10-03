using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day2
{


   public class calculator
    {
       public static void add(int a, int b)
        {
            int c = a + b;
            Console.WriteLine($"Result of addition {c}");


        }
       public void sub(int a, int b)
        {
            int c = a - b;
            Console.WriteLine($"Result of substraction is {c}");
        }
    }
}
