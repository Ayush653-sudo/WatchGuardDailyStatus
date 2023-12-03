
using Tooth_Booth_.common;
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.DatabaseHandler;

namespace Tooth_Booth_.View
{
    public static  class InputTaker
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
        public static string UserNameInput(string printStatement)
        {

            string userName;
            while (true)
            {

                Console.WriteLine(printStatement);
                userName = Console.ReadLine()!.Trim();

                if (CheckValidity.IsUserNameNotValid(userName))
                {

                    Console.WriteLine(PrintStatements.erroruserNamePrint);

                }
                else
                    break;
            }
            return userName;
        }

        public static string PasswordInput(string printStatement)
        {

            string password;
            while (true)
            {
                Console.WriteLine(PrintStatements.passwordPrint);
                

                password = MaskPassword();

                var isValidated = CheckValidity.IsValidPassword(password);

                if (!isValidated)
                {
                    Console.WriteLine(PrintStatements.errrorPasswordPrint);
                    
                }
                else
                    break;
            }
            return password;

        }

        public static string EmailInput(string printStatement)
        {
            string emailAddress;
            while (true)
            {

                Console.WriteLine(PrintStatements.emailAddressPrint);
                emailAddress = Console.ReadLine()!.Trim();

                if (!CheckValidity.IsValidEmail(emailAddress))
                {
                    Console.WriteLine(PrintStatements.erorEmailPrint);

                }
                else
                    break;

            }
            return emailAddress;
        }

        public static string PhoneNumberInput(string printStatement)
        {
           string phoneNumber;
            while (true)
            {
                Console.WriteLine(printStatement);

                phoneNumber = Console.ReadLine()!.Trim();

                bool isValidated = CheckValidity.IsValidPhoneNumber(phoneNumber);
                if (!isValidated)
                {
                    Console.WriteLine(PrintStatements.errorPhoneNumberPrint);
                  
                }
                else
                    break;
            }
            return phoneNumber;

        }

        public static string ClinicNameInput(string printStatement)
        {
            string clinicName;

            while (true)
            {
                Console.WriteLine(printStatement);
                clinicName = Console.ReadLine()!.Trim();

                if (CheckValidity.IsNotValidClinicName(clinicName))
                {

                    Console.WriteLine(PrintStatements.errorClinicPrint);
                  
                }
                else
                    break;

            }
            return clinicName;
        }

        public static string ClinicDescriptionInput(string printStatement)
        {
            string description;
            while (true)
            {
                Console.WriteLine(printStatement);
                description = Console.ReadLine()!.Trim();
                if (!CheckValidity.IsValidCountWords(description, 6))
                {
                    Console.WriteLine(PrintStatements.errorDescriptionPrint);

                }
                else
                    break;
            }
            return description; 
        }

        public static string ClinicCityInput(string printStatement)
        {
            string clinicCity;
            while (true)
            {
                Console.WriteLine(printStatement);
                clinicCity = Console.ReadLine()!.ToLower().Trim();
                if (CheckValidity.IsNotValidClinicCity(clinicCity))
                {
                    Console.WriteLine(PrintStatements.errorClinicCityPrint);

                }
                else
                    break;
            }
            return clinicCity;
        }

        public static DentistCategory DentistCategoryInput(string printStatement)
        {
            DentistCategory category=DentistCategory.GeneralDentist;
            DentistCategory pressedKey;
            while (true)
            {
                Console.WriteLine(printStatement);
                try
                {
                 pressedKey = (DentistCategory)Convert.ToInt32(Console.ReadLine());
                    switch (pressedKey)
                    {
                        case DentistCategory.GeneralDentist:
                            category = DentistCategory.GeneralDentist;
                            break;
                        case DentistCategory.Pedodontist:
                            category = DentistCategory.Pedodontist;
                            break;
                        case DentistCategory.Orthodontist:
                            category = DentistCategory.Orthodontist;
                            break;
                        case DentistCategory.Periodontis:
                            category = DentistCategory.Periodontis;
                            break;
                        case DentistCategory.Endodontist:
                            category = DentistCategory.Endodontist;
                            break;
                        case DentistCategory.OralPathologists:
                            category = DentistCategory.OralPathologists;
                            break;
                        case DentistCategory.Prosthodontist:
                            category = DentistCategory.Prosthodontist;
                            break;
                        default:
                            Console.WriteLine(PrintStatements.choiceCorrectlyPrint);
                            return category= DentistCategoryInput(printStatement);
                    }
                    break;

                }
                catch 
                {
                    Message.Invalid(PrintStatements.giveCorrectInput);

                }
               
                                                                   
            }
            return category;
        }
        public static int AppointmentIdInput(string printStatement)
        {
            int appointmentId;
            while (true)
            {
                Console.WriteLine(printStatement);
                if (!int.TryParse(Console.ReadLine(), out appointmentId))
                {
                    Message.Invalid(PrintStatements.giveCorrectInput);
                   
                }
                else
                    break;
            }
            return appointmentId;

        }

        public static DateTime DeteTimeInput(string printStatement)
        {
            DateTime dateTime;
            while (true)
            {
                Console.WriteLine(PrintStatements.dateOfAppointment);
                string dT = Console.ReadLine()!.Trim();
                var isValidDate = DateTime.TryParse(dT, out dateTime);
                if (isValidDate)
                    break;
                else
                    Console.WriteLine(PrintStatements.enterValidDate);
            }
            return dateTime;


        }

        public static int MaximumAppointmentInput(string printStatement)
        {

            int maxAppointment;
            while (true)
            {
                Console.WriteLine(printStatement);
                if (!int.TryParse(Console.ReadLine(), out maxAppointment) || maxAppointment < 0)
                {
                    Console.WriteLine(PrintStatements.giveCorrectInput);

                }
                else
                    break;
            }
            return maxAppointment;

        }
        public static bool MarkAttendance(string printStatement)
        {

            bool isPresent = false;
            while (true)
            {
                Console.WriteLine(printStatement);
                Console.WriteLine(PrintStatements.choiceEnter);
                Attendance pressedKey;
                try
                {
                    pressedKey = (Attendance)Convert.ToInt32(Console.ReadLine());
                    switch (pressedKey)
                    {
                        case Attendance.Present:
                            isPresent = true;
                            break;
                        case Attendance.Absent:
                            isPresent = false;
                            break;
                        default:
                            Console.WriteLine(PrintStatements.choiceCorrectlyPrint);
                            return isPresent = MarkAttendance(printStatement);

                    }
                    break;
                }
                catch (Exception ex)
                {
                    ExceptionDBHandler.handler.AddEntryToFile(ex.ToString());
                    Console.WriteLine(PrintStatements.giveCorrectInput);

                }
            }
            return isPresent;
           
        }
        public static string AddPrescription(string printStatement)
        {
            string prescription;
            while (true)
            {
                Console.WriteLine(printStatement);
                prescription = Console.ReadLine()!.Trim();
                if (CheckValidity.NullCheck(prescription))
                {
                    Console.WriteLine(PrintStatements.fieldCantNull);

                }
                else
                    break;
            }
            return prescription;

        }
    }


}
