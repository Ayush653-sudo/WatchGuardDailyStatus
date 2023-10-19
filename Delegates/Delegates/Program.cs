using System;
namespace delegate_Example4
{
    public delegate void Test();
    class Program
    {
        public delegate void delmethod(int x, int y);

        public class TestMultipleDelegate
        {
            public void plus_Method1(int x, int y)
            {
                Console.Write("You are in plus_Method");
                Console.WriteLine(x + y);
            }

            public void subtract_Method2(int x, int y)
            {
                Console.Write("You are in subtract_Method");
                Console.WriteLine(x - y);
            }
           public static void Display(int x)
            {
                Console.WriteLine(x);
            }
           public static int Add(int x, int y)
            {
                return x + y;
            }

        }

        static void Main(string[] args)
        {

            TestMultipleDelegate obj = new TestMultipleDelegate();
            delmethod del = new delmethod(obj.plus_Method1);

            // Here we have multicast
            del += new delmethod(obj.subtract_Method2);
            // plus_Method1 and subtract_Method2 are called
            del(50, 10);
            Console.WriteLine();
            //Here again we have multicast
            del -= new delmethod(obj.plus_Method1);
            //Only subtract_Method2 is called
            del(20, 10);
          //anonymous Delegate
            Test Display = delegate ()
            {
                Console.WriteLine("Anonymous Delegate method");
            };
            Action<int> f =TestMultipleDelegate.Display;

            f(10);
            Func<int, int, int> funcc = TestMultipleDelegate.Add; //first two int are parameter type. Last int is return type

            int x = funcc(10, 20);
            Console.WriteLine(x);

            //            Display();
        }
    }
}