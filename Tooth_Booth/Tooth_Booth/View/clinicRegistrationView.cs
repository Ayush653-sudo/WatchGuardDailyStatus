using System;


namespace ThoothTooth_Booth.View
{
	public class ClinicRegistration
	{
	
		public static registrationDetails()
		{
			var useName, passWord, emailAddress, phoneNumber, userType;

			AuthManager.commonUserDetails(useName, passWord, emailAddress, phoneNumber, userType);

            Console.WriteLine("Enter your clinicName: ");
			var clinicName = Console.ReadLine();
			Console.WriteLine("Choose Dentist category: ");
			var category = Console.ReadLine();
			Console.WriteLine("Enter small Description of your clinic: ");
			var description = Console.ReadLine();
			Console.WriteLine("Enter your clinic city: ");
			var clinicCity = Console.ReadLine();

			//Clinic newClinic = new Clinic();
			

		}

	}

}
