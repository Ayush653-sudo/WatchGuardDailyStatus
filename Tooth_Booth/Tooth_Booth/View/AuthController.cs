using System;

namespace ThoothTooth_Booth.View
{


	public class AuthManager
	{

      public static Registration()
		{
			Console.WriteLine("press 1 to register as a Patient");
			Console.WriteLine("Press 2 to register new clinic");
			var keyPressed = Console.ReadLine();
            
            if (keyPressed == "1")
            {
                //
            }
            else
            {
                ClinicRegistration.RegistrationDetails();
            }

		}
        public static commonUserDetails(out userName,out password,out emailAddress,out phoneNumber,out userType)
        {
            Console.WriteLine("Please Enter userName: ");
            var userName = Console.ReadLine();
            Console.WriteLine("Enter Your Password: ");
            var password = Console.ReadLine();
            Console.WriteLine("Enter your EmailAddress: ");
            var emailAddress = Console.ReadLine();
            Console.WriteLiine("Enter your PhoneNumber: ");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("Ennter userType: ");
            var userType = Console.ReadLine();
        }
     


	}


}