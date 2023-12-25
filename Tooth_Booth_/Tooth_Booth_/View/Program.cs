
using ThoothTooth_Booth_.View;
using Tooth_Booth_.common;
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.Config;
using Tooth_Booth_.Controller;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.View;

class Program
{
    IAuthController authController;
   public Program(IAuthController authController)
    {
        this.authController = authController;
    }
    
    public void StartApp()
    {

      
        while (true)
        {


            Console.WriteLine();
            Console.WriteLine(PrintStatements.frontScreenMenu);
            try
            {
                var pressKey = (SelectAuth)Convert.ToInt32(Console.ReadLine());

               
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
            catch(Exception ex) 
            {

                ExceptionDBHandler.handler.AddEntryToFile(ex.ToString());
                Message.Invalid(PrintStatements.giveCorrectInput);

            }

        }
       

      }
    public static void Main()
    {

        Program startProgram = new Program(new AuthController(new AuthDashboard(),UserDBHandler.handler,ClinicDBHandler.handler));
       startProgram.StartApp();

    }

}
