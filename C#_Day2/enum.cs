using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day2
{

    public enum shipped
    {
        shipped=1,
        notshipped=0,
    }
     class num
    {

        public void delivery()
        {
            shipped dummy1 = shipped.shipped;
            Console.WriteLine(dummy1);
            Console.WriteLine((shipped)(int)dummy1);
        }
    }
}
