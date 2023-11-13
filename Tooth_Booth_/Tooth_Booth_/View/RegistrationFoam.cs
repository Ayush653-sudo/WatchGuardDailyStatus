
using Tooth_Booth_.common;
using Tooth_Booth_.common.Enums;

using Tooth_Booth_.models;


namespace ThoothTooth_Booth_.View
{
	public class RegistrationFoam
	{
		public static String MaskPassword()
		{
            var password = string.Empty;
            ConsoleKey key; do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
			return password;
        }


       public static User GetUserDetails(int typeOfUser)
        {


        usernameretry:
            Console.WriteLine(PrintStatements.userNamePrint);
            var userName = Console.ReadLine()!.Trim();

            if (CheckValidity.NullCheck(userName) || CheckValidity.CheckLength(userName, 5) || !CheckValidity.CheckRegex(userName, CheckValidity.hasOnlyAlphaNumeric))
            {

                Console.WriteLine(PrintStatements.erroruserNamePrint);
                goto usernameretry;
            }

        passwordretry: Console.WriteLine(PrintStatements.passwordPrint);
            var password = MaskPassword();



            var isValidated = CheckValidity.CheckRegex(password, CheckValidity.hNumber) && CheckValidity.CheckRegex(password, CheckValidity.hasUpperChar) && CheckValidity.CheckRegex(password, CheckValidity.hasMinimum5Chars) && CheckValidity.CheckRegex(password, CheckValidity.hasSymbols);

            if (!isValidated)
            {
                Console.WriteLine(PrintStatements.errrorPasswordPrint);
                goto passwordretry;
            }

        emailretry: Console.WriteLine(PrintStatements.emailAddressPrint);
            var emailAddress = Console.ReadLine()!.Trim();

            if (!CheckValidity.CheckRegex(emailAddress, CheckValidity.emailRegex))
            {
                Console.WriteLine(PrintStatements.erorEmailPrint);
                goto emailretry;
            }

        phoneretry: Console.WriteLine(PrintStatements.phoneNumberPrint);
            var phoneNumber = Console.ReadLine()!.Trim();

            isValidated = CheckValidity.CheckRegex(phoneNumber, CheckValidity.hasnumber);
            if (!isValidated)
            {
                Console.WriteLine(PrintStatements.errorPhoneNumberPrint);
                goto phoneretry;
            }
            UserType userType = (UserType)typeOfUser;

            User user = new User(userName, password, emailAddress, phoneNumber, userType);
            return user;

        }

        internal static  Clinic ClinicRegistrationDetails(string userName)
		{
			

				

			clinicretry: Console.WriteLine(PrintStatements.clinicNamePrint);
				var clinicName = Console.ReadLine()!.Trim();

				if (CheckValidity.CheckLength(clinicName,6)||CheckValidity.NullCheck(clinicName))
				{

					Console.WriteLine(PrintStatements.errorClinicPrint);
					goto clinicretry;
				}

			clinicdescriptionretry: Console.WriteLine(PrintStatements.clinicDescriptionPrint);
				var description = Console.ReadLine()!.Trim();
				if (!CheckValidity.CountWords(description,6))
				{
					Console.WriteLine(PrintStatements.errorDescriptionPrint);
					goto clinicdescriptionretry;
				}
			clinicCityretry: Console.WriteLine(PrintStatements.clinicCity);
				var clinicCity = Console.ReadLine()!.ToLower().Trim();
				if (CheckValidity.NullCheck(clinicCity) || !CheckValidity.CheckRegex(clinicCity,CheckValidity.hasOnlyAlphabet)||CheckValidity.CheckLength(clinicCity,3))
				{
					Console.WriteLine(PrintStatements.errorClinicCityPrint);

					goto clinicCityretry;
				}

			

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
