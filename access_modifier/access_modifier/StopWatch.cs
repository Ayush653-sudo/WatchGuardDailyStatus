using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace access_modifier
{
    internal class StopWatch
    {
        DateTime _start;
        DateTime _end;
        public void calculateTime()
        {
            _start = DateTime.Now;
        }
        public void calculateEndTime()
        {
            _end= DateTime.Now;
           var diff = _end-_start;
            Console.WriteLine(diff);
        }
    }
}
