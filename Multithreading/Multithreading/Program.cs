using System;
using System.Threading;

//class Program
//{
//    static void Main()
//    {
//        // create a new thread
//        Thread t = new Thread(Worker);

//        // start the thread
//        t.Start();

//        // do some other work in the main thread
//        for (int i = 0; i < 10; i++)
//        {
//            Console.WriteLine("Main thread doing some work");
//            Thread.Sleep(100);
//        }

//        // wait for the worker thread to complete
//        t.Join();

//        Console.WriteLine("Done");
//    }

//    static void Worker()
//    {
//        for (int i = 0; i < 10; i++)
//        {
//            Console.WriteLine("Worker thread doing some work");
//            Thread.Sleep(100);
//        }
//    }
////}
//using System.Threading;
//using System;
//namespace ThreadingDemo
//{
//    class Program
//    {
//        static int Count = 0;

//        static void Main(string[] args)
//        {
//            Thread t1 = new Thread(IncrementCount1);
//            Thread t2 = new Thread(IncrementCount2);
//            Thread t3 = new Thread(IncrementCount3);

//            t1.Start();
//            t2.Start();
//            t3.Start();

//            //Wait for all three threads to complete their execution
//            t1.Join();
//            t2.Join();
//            t3.Join();



//            Console.WriteLine(Count);
//            Console.Read();
//        }

//        static void IncrementCount1()
//        {
//            for (int i = 1; i <= 1000000; i++)
//            {
//                Count++;
//            }
//        }
//        static void IncrementCount2()
//        {
//            for (int i = 1; i <= 1000000; i++)
//            {
//                Count++;
//            }
//        }
//        static void IncrementCount3()
//        {
//            for (int i = 1; i <= 1000000; i++)
//            {
//                Count++;
//            }
//        }
//    }
//}
//using System.Threading;
//using System;
//using System.Diagnostics.CodeAnalysis;

//namespace ThreadingDemo
//{
//    public interface su
//    {
//       public void sum();
//    }
//    public interface sk
//    {
//       public void sum();
//    }
//    class Program:su,sk
//    {
//        public void sum()
//        {
//            Console.WriteLine("sum");

//        }
//        static int Count = 0;

//        static void Main(string[] args)
//        {
           
            
            //Thread t1 = new Thread(IncrementCount);
            //Thread t2 = new Thread(IncrementCount);
            //Thread t3 = new Thread(IncrementCount);

            //t1.Start();
            
            //t2.Start();
            //t3.Start();

            ////Wait for all three threads to complete their execution
            //t1.Join();
            //t2.Join();
            //t3.Join();

            //Console.WriteLine(Count);
            //Console.Read();
//        }

//        private static readonly object LockCount = new object();
//        static void IncrementCount()
//        {
//            for (int i = 1; i <= 1000000; i++)
//            {
//                //Only protecting the shared Count variable
//                lock (LockCount)
//                {
//                    Count++;
//                }
//            }
//        }
//    }
//}
