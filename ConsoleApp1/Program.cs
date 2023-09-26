using System;


class poro
{
     static void Main(String[] ar)
    {
        try // using try catch just for demonstration purpose
        {     
            string demoVar1 = "11";
            int i = Convert.ToInt32(demoVar1);
            string a = "Ayush";
            string b = "Singh Tomar";
            Console.WriteLine("Hi {0} {1}", a,b);
            Console.WriteLine(i);
        }
        catch(Exception) {
            Console.WriteLine("use only numbers for demovar1");

        }
        int demoVar2 = 'A';
        string @int = "34";
        Console.WriteLine(@int);    

        Console.WriteLine((char)(demoVar2+1));
       
    }
}