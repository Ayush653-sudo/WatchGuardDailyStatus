
using C__DAY3;
using System;
using System.Globalization;

namespace Day3
{
    class sep27
    {
        static void Main(String[] args)
        {
            
            List<listCheck> listCheck = new List<listCheck>();
            String demo = "hello";
            String a1="he";
            String b1= "llo";
            String c1 = a1 + b1;

            Console.WriteLine(a1 == b1);
            Console.WriteLine(ReferenceEquals(c1,demo));
            //Console.WriteLine(b.Equals( a));

            /*  char[] c = { 'a', 'b', };
              char[] d = new char[2] { 'a', 'b' };
              var e = new char[] { 'a', 'b' };
              string s1 = new string(c);
              string s2 = new string(d);
              string s3 = "ab";
              Console.WriteLine(c == d);
              Console.WriteLine(s1 == s2);
              Console.WriteLine(s1.Equals(s2));
              Console.WriteLine(s1 == s3);
              Console.WriteLine(s1.Equals(s3));*/
            String a = new String("asdf");
            String b = new String("asdf");
            
           Console.WriteLine(a == b);  // False
            Console.WriteLine(ReferenceEquals(a, b));
            Console.WriteLine(a.Equals(b)); // True

            //Random Class
            Random rand = new Random();
            Console.WriteLine("Printing 10 random numbers" +
                                    " between 50 and 100");
            for (int i = 1; i <= 10; i++)
                Console.WriteLine("{0} -> {1}", i, rand.Next(50, 100));

            string[] s1 =  { "He", "llo" };
            string s2 = "llo";
            Console.WriteLine(string.Join(' ',s1));

            //List in c#

            var numbers = new List<int>();
            var numbers2 = new List<int>() { 1,2,3};
            var names = new List<string>() { "ayush", "Singh", "Tomar","Tomar" };
            foreach(var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine(names[0]);

            Console.WriteLine("Index of ayush: "+names.IndexOf("ayush"));
            Console.WriteLine("Last Index of Tomar: " + names.LastIndexOf("Tomar"));
            //Count it will count number of object in the list
           
            names.Remove("Tomar");
            names.Clear();
            Console.WriteLine("Count:" + names.Count);
           // Likes bogus= new Likes();
           // bogus.diaplay();
           // unique bogus1 = new unique();
           // bogus1.uniqu();
           Time g= new Time();
            g.TT();
            





        }
    }
}
