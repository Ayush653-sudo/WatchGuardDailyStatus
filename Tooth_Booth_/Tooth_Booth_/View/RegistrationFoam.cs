
using Tooth_Booth_.common;
using Tooth_Booth_.common.Enums;

using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace ThoothTooth_Booth_.View
{
	public class RegistrationFoam
	{
		
       public static User GetUserDetails(int typeOfUser)
        {
            Console.WriteLine();
            var userName = InputTaker.UserNameInput(PrintStatements.userNamePrint);

            var password =InputTaker.PasswordInput(PrintStatements.passwordPrint);

            var emailAddress = InputTaker.EmailInput(PrintStatements.emailAddressPrint);

            var phoneNumber = InputTaker.PhoneNumberInput(PrintStatements.phoneNumberPrint);
            UserType userType = (UserType)typeOfUser;

            User user = new User(userName, password, emailAddress, phoneNumber, userType);
            return user;

        }

        internal static  Clinic ClinicRegistrationDetails(string userName)
		{		
		    var clinicName = InputTaker.ClinicNameInput(PrintStatements.clinicNamePrint);
			var description = InputTaker.ClinicDescriptionInput(PrintStatements.clinicDescriptionPrint);
			var clinicCity = InputTaker.ClinicCityInput(PrintStatements.clinicCity);			

		    Clinic newClinic = new(userName, clinicName, description, clinicCity);

			return newClinic;		

		}

		internal static User PatientsRegistrationDetails()
		{		
				User user = GetUserDetails(3);
				return user;
		
			
        }

	}

}
