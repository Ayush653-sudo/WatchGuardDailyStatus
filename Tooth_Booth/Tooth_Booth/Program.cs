using model;
using System.Security.Cryptography.X509Certificates;

class Program
{

    public static void Main()
    {


        Console.WriteLine("Hi! Do you want to Login or Register");
        Console.WriteLine("Press 1 to Login or 2 or Register");
        var pressKey=Console.ReadLine();
        if (pressKey == "1")
        {

        }
        else
        {
            AuthManager.Registration();
        }


        
    }

}