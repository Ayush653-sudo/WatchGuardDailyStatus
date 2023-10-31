using System.Security.Principal;
using ThoothTooth_Booth_.View;
using Tooth_Booth_.common;
using Tooth_Booth_.Controller;
using Tooth_Booth_.View;

class Program
{
   public static void StartApp()
    {

        while (true)
        {


            Common.FrontScreenSelectMenu();
            try
            {
                var pressKey = (SelectAuth)Convert.ToInt32(Console.ReadLine());

                IAuthController authController = new AuthController();
                switch (pressKey)
                {
                    case SelectAuth.LogIn:
                        authController.LogIn();
                        break;

                    case SelectAuth.SignUp:
                        authController.SignUp();
                        break;


                    case SelectAuth.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("please Choose correct options");
                        break;

                }
            }
            catch (Exception ex) { 
                
                Message.Invalid("Give Correct Input");

            }

        }
       

      }
    public static void Main()
    {


        StartApp();

    }

}
