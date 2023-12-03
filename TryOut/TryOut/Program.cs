using ClassLibrary1;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using TryOut;

public class A
{
    public virtual void fun()
    {
        Console.WriteLine("class a function called");
    }
}
public class B : A
{
    
    //public static void fun()
    //{
    //    Console.WriteLine("static of class B called");
    //}
    public override void fun()
    { 
        
        Console.WriteLine("simple function of class B is called");
    }

}

public class Program
{
    public static void Main()
    {
        Class1 k = new Class1();
        Class1.Main();
        Console.WriteLine("Hello World");
        A obj = new B();
       obj.fun();//will not work
       // staticCheck obj1 = new staticCheck();
        int? a = null;
        int b = 10;
      //  Console.WriteLine(a || b);

    }
}