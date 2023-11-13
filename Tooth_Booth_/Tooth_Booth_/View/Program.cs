
using Tooth_Booth_.common;
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.Config;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.View;

class Program
{
   public static void StartApp()
    {

        while (true)
        {


            Console.WriteLine(PrintStatements.frontScreenMenu);
            try
            {
                var pressKey = (SelectAuth)Convert.ToInt32(Console.ReadLine());

                IAuthController authController = ControllerConfig.GetAuthController();
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
                        Console.WriteLine(PrintStatements.giveCorrectInput);
                        break;
                }
            }
            catch(Exception ex) {

                ExceptionDBHandler.handler.AddEntryAtDB<String>(ExceptionDBHandler.handler.ExceptionPath, ex.ToString(), ExceptionDBHandler.handler.ListOfException);
                Message.Invalid(PrintStatements.giveCorrectInput);

            }

        }
       

      }
    public static void Main()
    {
     
        StartApp();

    }

}
