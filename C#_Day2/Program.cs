using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

using C__Day2;

using System;
using System.Threading.Tasks;
using System.Diagnostics;
namespace SingletonDemo
{

    using System;
    namespace SingletonDemo
    {
        public class Singleton
        {
            private static int Counter = 0;
            private static Singleton Instance = null;
            public static Singleton GetInstance()
            {
                if (Instance == null)
                {
                    Instance = new Singleton();
                }
                return Instance;
            }
            private Singleton()
            {
                Counter++;
                Console.WriteLine("Counter Value " + Counter.ToString());
            }
            public class DerivedSingleton : Singleton
            {
            }
        }

        class Demo1
        {
            public static void Main()
            {
                Singleton fromTeachaer = Singleton.GetInstance();
                Singleton.DerivedSingleton derivedObj = new Singleton.DerivedSingleton();
            }

        }





    }
}









    //public class Logger
    //{
    //    public static int i = 0; 
    //    private Logger()
    //    {
    //        i++;
    //        Console.WriteLine("Cosntructor called"+i);
    //    }
    //    private static class LoggerHolder
    //    {
    //        public static Logger logger = new Logger();
    //    }
    //    public static Logger getInstance()
    //    {
    //        return LoggerHolder.logger;
    //    }
    //}

    //public class A
    //{
    //    public static void Main(String[] args)
    //    {
    //        // Logger.i = 10;
    //        Logger.i = 10;
    //        Logger.getInstance();
    //        Logger.getInstance();
    //        Logger.getInstance();
    //    }
    //}

    //class Demo
    //{
    //    // private var a = 0;


    //    static void Main(String[] args)
    //    {
    //      Demo1.pri();
    //    calculator.add(1, 2);
    //    calculator res=new calculator();
    //    res.sub(8, 4);
    //    //usning array
    //    int[] arr = new int[3];
    //    arr[0] = 1;
    //    arr[1] = 4;
    //    arr[2]=5;

    //    }

    //}
   
    

