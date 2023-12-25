using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    using System;
    namespace SingletonDemo
    {
        public sealed class Singleton
        {
            private static int Counter = 0;
            private static Singleton Instance = null;
            private static readonly object Instancelock = new object();
            public static Singleton GetInstance()
            {
                lock (Instancelock)
                { 
                    if (Instance == null)
                    {
                        Instance = new Singleton();
                    }
                } 
                return Instance;
            }

            private Singleton()
            {
                Counter++;
                Console.WriteLine("Counter Value " + Counter.ToString());
            }
            public void PrintDetails(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
