using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
   class ManualReset
    {
    private  ManualResetEvent mrev=new ManualResetEvent(false);





        public  void Worker()
        {
            mrev.Set();
            Console.WriteLine("worker Function is called");
            Thread.Sleep(5000);
            Console.WriteLine("Worker function is ended");
            mrev.Reset();
        }
       public void Contractor()
        {
            Console.WriteLine("Contractor function Callled");
            mrev.WaitOne();
            Console.WriteLine("Contractor function is ended");
        }
        public static  void Main()
        {
            ManualReset m1=new ManualReset();
            Thread t1 = new Thread(m1.Worker);
            Thread t2 = new Thread(m1.Contractor);
            t1.Start();
            t2.Start();


        }

    }
}
