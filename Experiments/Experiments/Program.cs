using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace area
{  /// <summary>
/// xml documentation comment
/// </summary>
   
    enum day
    {
        Monday,
        Tuesday
    }
    class experiments
    {
        public readonly int myvar1;  //can't declare inside the function,it is a run time constant
        static void Main(string[] args)
        {
            //About Nullable non-primitive data-type can be null but primitive needs extra supports 
            //suppose we have bool variable named areyoumajor and you do not want to give either true or false
            //we can't assign non nullable data type to a nullable data-type directly
            bool? areYoumajor = null;
            //  bool justfordemo = (bool)areYoumajor; or bool justfordemo=areYoumajor??0;
            //  Console.WriteLine(areYoumajor);

            //Conversion

            float x = 7332333333333.45f;
            int i = (int)x;   //integer can't handle this much large number but this technique of conversion
                              //would not give exception instead it will give minimum value that any integer handle
           //int y=Convert.ToInt32(x);//this would throw an runtime exception 
            int dumm;
            string s = "10";
            bool k = int.TryParse(s, out dumm);//simple parse method would throw exception if not valid input is given
            if (k)
            {
                Console.WriteLine(dumm);
            }
            int kk=9;//must have to intialize to send as reference
            change(ref kk);
            int add;
            int sub;
            out_Based(2, 3, out add, out sub);
            Console.WriteLine("add " + add + "substract " + sub);
            Parameter1();
            Parameter1(1, 2, 3);
            int[] arr= new int[2] {1,2};
            //   Parameter1(arr);
              boxing();
            //  dyna("Cat", "Dog");
            // dyna("Hello", 1232);
          
            // Using digit separators
            long num1 = 1_00_10_00_00_00;
        

        }
         //When you assign a class object to the dynamic type, then the compiler does not check for
        //the right method and property name of the dynamic type which holds the custom class objec 
       
        public static void dyna(dynamic s1, dynamic s2)
        {   
        Console.WriteLine(s1 + s2);  //var myvalue = 10; // statement 1 myvalue = “GeeksforGeeks”; // statement 2 Here the compiler will throw an error because
                                         //the compiler has already decided the type of the myvalue variable using statement 1 that is an integer type.
                                         //When you try to assign a string to myvalue variable, then the compiler will give an error because it violating safety rule type.
        }
        static void change(ref int j)//reference parameter
        {
            j = 10;
        }
        static void out_Based(int a,int b,out int add,out int sub)  //output parameter
        {
            add = a + b;
            sub = a - b;//must initialize both out variable other would give error
          

        }
        static void Parameter1(params int[] arr)//params type paramter it handle many arguments at once 
        {
            Console.WriteLine("length " + arr.Length);
            foreach (int i in arr)
                Console.WriteLine(i);
        }

        static void boxing()
        {
            int i = 143;
            object o = i;
        Console.WriteLine(o);
            double e = 2.718281828459045;
            double d = e;
            object o1 = e;
            object o2 = o1;
            //Console.WriteLine(d == e);
            //Console.WriteLine(object.ReferenceEquals(o1,o2));
            o1 = "dd";
            Console.WriteLine(o1);
            Console.WriteLine(e);
            day dd = (day)1;
            Console.WriteLine(dd);
            Experiment2 kl ;
            //  kl.data(); not a valid task
            int i1 = 15;
            object ob = i1;
            Console.WriteLine(object.ReferenceEquals(i1, ob));

            unsafe
            {
                int* ptr = &i1;
                //  Console.WriteLine(*(ptr));
                Console.WriteLine(Convert.ToString((long)ptr, 16));
               object* obp = &ob;
                Console.WriteLine(Convert.ToString((long)obp, 16));


            }
            ob = 16;
            unsafe
            {
                object* obp = &ob;
                Console.WriteLine(Convert.ToString((long)obp, 16));
            }


        }
        

    }
    class Experiment2
    {
        int i;
        public void data()
        {
            i = 90;
        }
    }

}
