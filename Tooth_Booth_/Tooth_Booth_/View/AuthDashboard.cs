
using Tooth_Booth_.common;
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.models;
using Tooth_Booth_.View;
using Tooth_Booth_.View.Interfaces;

namespace ThoothTooth_Booth_.View
{

    public class AuthDashboard : IAuthDashboard
    {

        public Dictionary<string, string> LogInView()
        {

            Console.WriteLine("-------------------------------------------LOGIN------------------------------------------");


            string userName;
            while (true)
            {
                Console.WriteLine(PrintStatements.userNamePrint);
                userName = Console.ReadLine()!.Trim();
                if (CheckValidity.NullCheck(userName))
                {
                    Console.WriteLine(PrintStatements.erroruserNamePrint);

                }
                else
                {
                    break;
                }
            }
            string password;
            while (true)
            {
                Console.WriteLine(PrintStatements.passwordPrint);

                password = InputTaker.MaskPassword().Trim();
                if (CheckValidity.NullCheck(password))
                {
                    Console.WriteLine(PrintStatements.errrorPasswordPrint);

                }
                else
                    break;
            }
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["username"] = userName;
            dict["password"] = password;
            return dict;

        }

        public User RegistrationView()
        {
            Console.WriteLine(PrintStatements.registrationStartView);
            int key;
            if (!int.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine(PrintStatements.giveCorrectInput);
            }
            var keyPressed = (Registrationstarter)key;


            try
            {

                switch (keyPressed)
                {
                    case Registrationstarter.PatientRegistration:
                        return RegistrationFoam.GetUserDetails(3);

                    case Registrationstarter.ClinicRegistration:
                        return RegistrationFoam.GetUserDetails(1);


                   
                    default:
                        Console.WriteLine(PrintStatements.choiceCorrectlyPrint);
                        RegistrationView();
                        break;

                }

            }
            catch (Exception ex) 
            {
                ExceptionDBHandler.handler.AddEntryToFile(ex.ToString());
                Console.WriteLine(PrintStatements.someThingWentWrong);
            }
            return null;


        }





    }


}