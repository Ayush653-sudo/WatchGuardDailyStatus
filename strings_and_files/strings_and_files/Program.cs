using System;
using System.Collections;
using System.Text;
using strings_and_files;
namespace file_s
{
    class Program
    {
        static void Main(string[] args)
        {    // var list=new List<char>v;

            ArrayList l=new ArrayList();
            l.Add(2);
            Console.WriteLine(l.Capacity);
            var fullName = "Ayush Tomar";
            Console.WriteLine("Trim:{0}",fullName.Trim());
            Console.WriteLine("ToUpper: {0}", fullName.Trim().ToUpper());
            int index = fullName.IndexOf(' ');
            string firstName=fullName.Substring(0,index);
            string lastName=fullName.Substring(index+1);
            Console.WriteLine("firstName: "+firstName);
            Console.WriteLine("lastName: " + lastName);
            var name = fullName.Split(' ');
            Console.WriteLine("firstName via split method: " + name[0]);
            Console.WriteLine("lastName via split method: " + name[1]);
            Console.WriteLine(fullName.Replace("Ayush", "Ayush Singh"));
            if (String.IsNullOrEmpty(fullName)) //it will validate the string if we have white space therefore we introduce another method
            Console.WriteLine("Invalid");
            if (String.IsNullOrWhiteSpace(" "))
                Console.WriteLine("Invalid");
            var str = "25";
            var age = Convert.ToByte(str);
            Console.WriteLine(age);
            float price = 29.95f;
            Console.WriteLine(price.ToString("C0"));
            /* String ay = "HELLO";
             const String AS = "HE";
             const String AB = "LLO";
             const String SUM = AS + AB;
             Console.WriteLine(String.ReferenceEquals(SUM, ay));*/
            string s1 = "";
            string s2 = "";
            Console.WriteLine(String.ReferenceEquals(s1,s2));

            // Modeifed("it will validate the string if we have white space therefore we introduce another method");
            //  stringbuild();
            // separate();
            //  isvalid();
          //  files obj = new files();
          //  obj.fileOpen();
               //throw new ArgumentOutOfRangeException()


        }
        static void Modeifed(String text)
        {
            const int maxL = 15;
            if(text.Length<maxL)
                Console.WriteLine(text);
            else
            {
                var resultw = new List<String>();
               
                var words= text.Split(' ');
                var TotChar = 0;
                foreach(var word in words)
                {
                    resultw.Add(word);
                    TotChar += word.Length;
                    if (TotChar > maxL)
                        break;
                }
                string h = String.Join(" ", resultw)+"...";
                Console.WriteLine(h);
                Console.WriteLine("Do you want to see whole text press 1 else do nothing");
                string bo = Console.ReadLine();
                if (!String.IsNullOrEmpty(bo) && bo == "1")
                    Console.WriteLine(text);
            }
        }
        static void stringbuild()
        {
            //it does not provide benefits like indexOf(),Contains(),StartsWith(),etc
            //unlike string it can be use for manipulation purpose like Append,Insert,Remove,Replace,Clear,etc
            var builder = new StringBuilder("Hello");
            builder.Append('-', 10);
            builder.AppendLine();
            builder.Append("Header");
            builder.AppendLine().Replace('-','+').Insert(5,new string(" Ayush"));
            Console.WriteLine(builder);

        }
        static void separate()
        {
            Console.WriteLine("Enter your hyphen separated String of number ");
           // var builder = new StringBuilder(Console.ReadLine());
           var s= Console.ReadLine();
            var sep = s.Split('-');
            bool first = false,second=false,des=false,ins=false,isres=false;
            int dum=0;
            foreach(var word in sep)
            {
                int dummy=Convert.ToInt32(word);

                if (second)
                {
                  //  Console.WriteLine(dummy + "ll" + dum);
                    second = false;
                    if (dummy == dum - 1)
                    {
                        des = true;
                        dum = dummy;
                    }
                    else if (dummy == dum + 1)
                    { ins = true;
                        dum = dummy;
                    }
                    else
                    {
                        isres = true;
                        Console.WriteLine("Not a consecutive pair");
                        break;
                    }
                
                }
               else if (!first)
                {
                    dum = dummy;
                    first = true;
                    second = true;
                }
                else
                {
                  //  Console.WriteLine(dummy + "ll" + dum);
                    if (des)
                    {

                        if (dummy != dum - 1)
                        {  isres= true;
                            Console.WriteLine("Not a consecutive pair");
                            break;
                        }
                        dum = dummy;
                    }
                    if (ins)
                    { 
                        if(dummy!=dum+1)
                        {
                            isres = true;
                            Console.WriteLine("Not a consecutive pair");
                            break;
                        }
                        dum = dummy; 
                    }
                }

            }
            if (!isres)
                Console.WriteLine("Given string contain all consecutive pairs");

        }
        static void isvalid()
        {
            Console.WriteLine("Enter Time");
            string tim = Console.ReadLine();
            var formt = tim.Split(":");
            int hour = int.Parse(formt[0]);
            int min = int.Parse(formt[1]);
            if (!(hour >= 0 && hour <= 23 && min >= 0 && min <= 60))
                Console.WriteLine("Not a Valid Time");
            else
                Console.WriteLine("You have entered a Valid Time");
      
        }
    }
}