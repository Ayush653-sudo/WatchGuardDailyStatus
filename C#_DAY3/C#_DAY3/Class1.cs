using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__DAY3
{
    internal class Likes
    {
        public void diaplay()
        {
            Console.WriteLine("Enter names of people who like your post ");
            var names=new List<string>();
            int count = 0;
            while (true)
            {
                Console.WriteLine("Hey Do you want to add? ");
                string dummy=Console.ReadLine();
                if(dummy != null&&dummy!=" ") {
                    if (count < 2)
                    { names.Add(dummy); }
            count++;
                }
                else
                {
                    if(count>2) { names.Add(count-2+" other"); }
                    break;
                }


            }
            String ans=String.Join(",", names);
            Console.WriteLine(ans);
        }

    }
}
namespace C__DAY3
{
    internal class unique
    {
        public void uniqu()
        {
            int count = 0;
            var dumm = new List<int>();
            while (count < 5)
            {
                Console.WriteLine("Enter number: ");
                int adder = Convert.ToInt32(Console.ReadLine());
                if (dumm.IndexOf(adder) != -1)
                {
                    Console.WriteLine("oh! try again ");
                }
                else
                {
                    dumm.Add(adder);
                    count++;
                }

            }
            dumm.Sort();
            Console.WriteLine("following are your unique numbers ");
            foreach (int i in dumm)
            {
                Console.WriteLine($"{i} ");
            }

        }
    }
}
