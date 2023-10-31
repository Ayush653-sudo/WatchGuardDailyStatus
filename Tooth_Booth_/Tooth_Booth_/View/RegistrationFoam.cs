using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Tooth_Booth_.common;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace ThoothTooth_Booth_.View
{
	public class RegistrationFoam
	{
		internal static User GetUserCommonDetails(int typeOfUser)
		{

			
			usernameretry: Console.WriteLine("Please Enter userName: ");
				var userName = Console.ReadLine()!.Trim();

				if (Common.NullCheck(userName)|| Common.CheckLength(userName,5)||!Common.hasOnlyAlphaNumeric.IsMatch(userName))
				{
					
					Console.WriteLine("Your UserName Must Be Greate Than 5 and only alphanumeric is acceptable");
					goto usernameretry;
				}
				
                passwordretry: Console.WriteLine("Enter Your Password: ");
				var password = Console.ReadLine()!.Trim();



				var isValidated = Common.hNumber.IsMatch(password) && Common.hasUpperChar.IsMatch(password) && Common.hasMinimum5Chars.IsMatch(password) && Common.hasSymbols.IsMatch(password);

				if (!isValidated)
				{
					Console.WriteLine("Your Password Must Be Greate Than 5 Kindly Retry and must contain one upper case letter , special symbol and number");
					goto passwordretry;
				}



			emailretry: Console.WriteLine("Enter your EmailAddress: ");
				var emailAddress = Console.ReadLine()!.Trim();

				if (!Common.CheckEmail(emailAddress))
				{
					Console.WriteLine("Please Enter A valid Email");
					goto emailretry;
				}

			phoneretry: Console.WriteLine("Enter your PhoneNumber: ");
				var phoneNumber = Console.ReadLine()!.Trim();

				isValidated = Common.hasnumber.IsMatch(phoneNumber);
				if (!isValidated)
				{
					Console.WriteLine("Enter valid phone number");
					goto phoneretry;
				}
				UserType userType = (UserType)typeOfUser;


				User user = new User(userName, password, emailAddress, phoneNumber, userType);
				return user;

			
			
			
        }
		internal static  Clinic ClinicRegistrationDetails()
		{
			

				User user = GetUserCommonDetails(1);

			clinicretry: Console.WriteLine("Enter your clinicName: ");
				var clinicName = Console.ReadLine()!.Trim();

				if (String.IsNullOrEmpty(clinicName)||clinicName.Length<5)
				{

					Console.WriteLine("Clinic Name Must Be Greate Than 5");
					goto clinicretry;
				}

			clinicdescriptionretry: Console.WriteLine("Enter small Description of your clinic: ");
				var description = Console.ReadLine()!.Trim();
				if (Common.CountWords(description)<5)
				{
					Console.WriteLine("Description must contain Word more than 6 for description");
					goto clinicdescriptionretry;
				}
			clinicCityretry: Console.WriteLine("Enter your clinic city: ");
				var clinicCity = Console.ReadLine()!.ToLower().Trim();
				if (Common.NullCheck(clinicCity) || !Regex.IsMatch(clinicCity, @"^[a-zA-Z]+$")||Common.CheckLength(clinicCity,3))
				{
					Console.WriteLine("Clinic City must not empty");

					goto clinicCityretry;
				}

			

				Clinic newClinic = new(user, clinicName, description, clinicCity);

				return newClinic;

			
			

		}

		internal static Patient PatientsRegistrationDetails()
		{

			
				User user = GetUserCommonDetails(3);

				Patient newPatient = new Patient(user);

				return newPatient;
		
			
        }

	}

}
