using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sealed_Class
{
    using System;

    class Printer
    {

        public virtual void show()
        {
            Console.WriteLine("display dimension : 6*6");
        }

      
        public virtual void print()
        {
            Console.WriteLine("printer printing....\n");
        }
    }


    class LaserJet : Printer
    {

         sealed override public void show()
        {
            Console.WriteLine("display dimension : 12*12");
        }

        override public void print()
        {
            Console.WriteLine("Laserjet printer printing....\n");
        }
    }


    class Officejet : LaserJet
    {


        override public void print()
        {
            Console.WriteLine("Officejet printer printing....");
        }
    }


   

}
