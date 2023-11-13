
using ThoothTooth_Booth_.View;
using Tooth_Booth_.common;
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.models;
using Tooth_Booth_.View.Interfaces;

namespace Tooth_Booth_.View
{
    class ClinicAdminDashboard : IClinicAdminDashboard
    {
       public IDentistController dentistController { get; set; }
        public ClinicAdminDashboard( IDentistController dentistController)
        {
           
            this.dentistController = dentistController;
        }
        public void StartClinicAdminDashboard(Clinic obj)
        {

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(PrintStatements.welcome + PrintStatements.whiteSpace + obj.clinicName);

                Console.WriteLine(PrintStatements.clinicMenu);

                try
                {
                    var pressedKey = (ClinicStarter)Convert.ToInt32(Console.ReadLine());
                    switch (pressedKey)
                    {
                        case ClinicStarter.RegisterDentist:
                            DentistRegistrationDashboard(obj);
                            break;

                        case ClinicStarter.DeleteDentist:
                            DeleteDentistAtClinic(obj);
                            break;

                        case ClinicStarter.ListOfDentist:
                            ShowDentistAtClinic(obj);
                            break;

                        case ClinicStarter.LogOut:
                            obj = null;
                            Program.StartApp();
                            return;

                    }
                }
                catch (Exception ex) 
                {
                    ExceptionDBHandler.handler.AddEntryAtDB<String>(ExceptionDBHandler.handler.ExceptionPath, ex.ToString(), ExceptionDBHandler.handler.ListOfException);
                    Message.Invalid(PrintStatements.someThingWentWrong);
                }
            }

        }
        public void DeleteDentistAtClinic(Clinic obj)
        {
            Console.WriteLine(PrintStatements.dentistUserNameToChange);
            var userName = Console.ReadLine()!.Trim();

            if (dentistController.DeleteDentistAtClinic(obj.listOFClinicAdmin[0], userName))
                Console.WriteLine(PrintStatements.updateSucessFully);
            else
            {
                Console.WriteLine(PrintStatements.someThingWentWrong);
            }


        }

        public void DentistRegistrationDashboard(Clinic obj)
        {
            Console.WriteLine(PrintStatements.dashedEnterDetailOfDentist);

            User user = RegistrationFoam.GetUserDetails(2);
        dentistcategory: Console.WriteLine(PrintStatements.chooseDentistCategory);
            Console.WriteLine(PrintStatements.dentistCategory);
            DentistCategory pressedKey;
            try
            {
                pressedKey = (DentistCategory)Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Message.Invalid(PrintStatements.giveCorrectInput);
                goto dentistcategory;
            }
            DentistCategory category = DentistCategory.GeneralDentist;
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
                    goto dentistcategory;

            }

            Dentist newDentist = new Dentist(user.userName, obj.clinicName,category, 0);
            if (dentistController.RegisterNewDentistAtClinic(user,newDentist))
                Console.WriteLine(PrintStatements.registerDentistSucessful);
            else
            {
                Console.WriteLine(PrintStatements.tryAgain);
                return;
            }


        }
        public void ShowDentistAtClinic(Clinic obj)
        {
            List<Dentist> listOfDentist = dentistController.GetDentistAtClinic(obj.clinicName);
            if (listOfDentist.Count == 0)
            {
                Console.WriteLine(PrintStatements.noDentistAvaliable);
                return;
            }

            Console.WriteLine(PrintStatements.followingDentist);
            foreach (Dentist d in listOfDentist)
            {
                Console.WriteLine(PrintStatements.dashedLine);

                Console.WriteLine(PrintStatements.dentistName + d.userName + PrintStatements.dentistspecialization + d.category);

            }
            Console.WriteLine(PrintStatements.dashedLine);


        }
    }
}
