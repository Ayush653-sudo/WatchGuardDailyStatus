using System;
using System.Reflection.Emit;
using Tooth_Booth_.common;
using Tooth_Booth_.Controller;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace ThoothTooth_Booth_.View
{


	public class AuthDashboard
	{

       
        public Dictionary<string,string> LogInView()
        {

            Console.WriteLine("-------------------------------------------LOGIN------------------------------------------");
         

   label:   Console.WriteLine("Enter your userName: ");
            var userName = Console.ReadLine()!.Trim();
            Console.WriteLine("Enter your password: ");
            var password = Console.ReadLine()!.Trim();
            if(Common.NullCheck(userName)||Common.NullCheck(password))
            {
                Console.WriteLine("Fields can't Be Null Or Empty");
                goto label;
            }
            Dictionary<string,string>dict=new Dictionary<string,string>();
            dict["username"] = userName;
            dict["password"] = password;
            return dict;
         
        }

        public  dynamic RegistrationView()
		{
			Common.RegistrationStartView();
            int key;
			if( !int.TryParse(Console.ReadLine(),out key))
            {
                Console.WriteLine("Enter a valid choice");
            }
            var keyPressed = (Registrationstarter)key;

            try
            {

                switch (keyPressed)
                {
                    case Registrationstarter.PatientRegistration:
                        return RegistrationFoam.PatientsRegistrationDetails();
                        
                    case Registrationstarter.ClinicRegistration:
                        return RegistrationFoam.ClinicRegistrationDetails();
                        

                    case Registrationstarter.GoBack:
                        Program.StartApp();
                        return null;
                    default:
                        Console.WriteLine("Please Enter A Valid Input");
                        RegistrationView();
                        break;

                }

            }
            catch
            {
                Console.WriteLine("SomeThing Went Wrong ");
            }
            return null;
          

		}
      

	}


}