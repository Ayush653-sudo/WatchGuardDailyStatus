using System;
using System.Threading;


public delegate void SumOf(int x);
class HelloWorld
{
   public static void display(int s)
    {
        Console.WriteLine("Sum is :"+s);
    }
    static void Main()
    {
     
     ParameterizedThreadStart obj = new ParameterizedThreadStart(show);

        SumOf _callback = new SumOf(display); 
     Thread t = new Thread(obj);
     t.Start(4);

    }
    public static void show(Object i)
    {
        for (int j = 0; j < (int)i; j++)
            Console.WriteLine(j);
    }








}
