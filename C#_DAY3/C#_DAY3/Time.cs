using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__DAY3
{
    internal class Time
    {
       public void TT()
        {
            var dateTime = new DateTime(2015, 1, 1);
            var now = DateTime.Now;
            var today = DateTime.Today;
            Console.WriteLine("NOW: " + now);
            Console.WriteLine("Today: " + today);
            var tomrrow=now.AddDays(1);
            var yesterday = now.AddDays(-1);
            Console.WriteLine($"tomrrow:{tomrrow} ");
            Console.WriteLine();
            Console.WriteLine(now.ToLongDateString());
            Console.WriteLine(now.ToShortDateString());
            Console.WriteLine(now.ToLongTimeString());
            Console.WriteLine(now.ToShortTimeString());
            Console.WriteLine(now.ToString("yyyy-MM-dd HH"));
            var start = DateTime.Now;
            var end=DateTime.Now.AddMinutes(2);
            var duration = end - start;
            Console.WriteLine("Duration: " + duration);
            Console.WriteLine();
            //Timespane objects
            var timeSpan = new TimeSpan(1, 2, 3);
            Console.WriteLine("Add Example: " + timeSpan.Add(TimeSpan.FromMinutes(8)));
        
        }
    }
}
