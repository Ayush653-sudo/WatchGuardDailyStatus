using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    class Monitor_Pulse
    {
        static Object _lock=new Object();
        //public static void Main()
        //{
        //  //  Console.WriteLine("ff");
        //    Thread t1 = new Thread(Write);
        //    Thread t2 = new Thread(Read);
        //    Thread t3 = new Thread(FF);
        //    t1.Start();
        //    t2.Start();
        //    t3.Start();

        //    t1.Join();
        //    t2.Join();
        //    t3.Join();
        //    Console.ReadLine();
        //}

        public static void Write()
        {
            Monitor.Enter(_lock);
            for(int i = 0; i < 5; i++)
            {
                Monitor.Pulse(_lock);
                Console.WriteLine("Write Thread Wroking.. "+i);
                Console.WriteLine("Write Thread Completed.. " + i);
                Monitor.Wait(_lock);

            }
        }
        public static void Read()
        {
            Monitor.Enter(_lock);
            for (int i = 0; i < 5; i++)
            {
                Monitor.Pulse(_lock);
                Console.WriteLine("Read Thread Wroking.. " + i);
                Console.WriteLine("Read Thread Completed.. " + i);
                Monitor.Wait(_lock);
            }

        }
        public static void FF()
        {
            Monitor.Enter(_lock);
            for (int i = 0; i < 5; i++)
            {
                Monitor.Pulse(_lock);
                Console.WriteLine("FF Thread Wroking.. " + i);
                Console.WriteLine("FF Thread Completed.. " + i);
                Monitor.Wait(_lock);

            }

        }

    }
}
