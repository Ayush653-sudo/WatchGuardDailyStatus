using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments_Intermediate_course
{
    class Abstract_Class
    {
        public  int i=90;
        public virtual void Func()
        {
            Console.WriteLine("HI1");
        }
    }
    class Derived :Abstract_Class
    {
        //public override void Func()
        //{
        //   Console.WriteLine("Hi2");
        //}
    }
}
