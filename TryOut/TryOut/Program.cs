using System;
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
    private void fun()
    {
        Console.WriteLine("simple function of class B is called");
    }

}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World");
        B obj = new B();
        // obj.fun();//will not work
        staticCheck obj1 = new staticCheck();
        int? a = null;
        int b = 10;
        Console.WriteLine(a || b);
    }
}