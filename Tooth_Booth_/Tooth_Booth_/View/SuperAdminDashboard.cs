
using ThoothTooth_Booth_.View;
using Tooth_Booth_.common;
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.models;
using Tooth_Booth_.View.Interfaces;

namespace Tooth_Booth_.View
{
    public class SuperAdminView:ISuperAdminView

    {
         ISuperAdminController superAdminController;
         IClinicControllerForSuperAdmin clinicController;
      public SuperAdminView(ISuperAdminController superAdminController, IClinicControllerForSuperAdmin clinicController)
        {
            this.superAdminController = superAdminController;
            this.clinicController = clinicController;
        }
        public void StartSuperAdminView(User user)
        {

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(PrintStatements.superAdminMenu);

                try
                {
                    SelectSuperAdminStarter pressKey = (SelectSuperAdminStarter)Convert.ToInt32(Console.ReadLine());



                    switch (pressKey)
                    {
                        case SelectSuperAdminStarter.ListOfClinic:
                            ViewListOfAvailableClinic(user);
                            break;

                        case SelectSuperAdminStarter.ModifyClinic:
                            EditClinicDashboard(user);
                            break;
                        case SelectSuperAdminStarter.DeleteClinic:
                            DeleteAnyClinic(user);
                            break;
                        case SelectSuperAdminStarter.AddAdmin:
                            AddMoreAdmin(user);
                            break;
                        case SelectSuperAdminStarter.LogOut: 
                            LogOut(user); 
                            break;
                        default:
                            Console.WriteLine(PrintStatements.choiceCorrectlyPrint);
                            break;

                    }
                }
                catch 
                {
                    Console.WriteLine(PrintStatements.giveCorrectInput);
                  

                }


            }


        }

        void ViewListOfAvailableClinic(User user)
        {
           List<Clinic>clinics= clinicController.GeListOfAllClinic();

            if(clinics.Count==0)
            {
                Console.WriteLine(PrintStatements.novAilableClinicPrint);
            }
           
               Console.WriteLine(PrintStatements.listOfClinicPrint);

            foreach(var obj in clinics) 
            {
                
                Console.WriteLine(PrintStatements.clinicNameArrow+ obj.clinicName);
                Console.WriteLine(PrintStatements.descriptionArrow + obj.description);
                Console.WriteLine(PrintStatements.clinicCityArrow + obj.clinicCity);
                Console.WriteLine(PrintStatements.verifiedArrow+obj.isverified);
                Console.WriteLine();

            }


        }

        void EditClinicDashboard(User superadmin)
        {
            var userName = InputTaker.UserNameInput(PrintStatements.userNameClinicEntry);
               Clinic obj=clinicController.GetClinicByClinicName(userName);
            if(obj==null)
            {
                Console.WriteLine(PrintStatements.enterUserNameCorrectly);
                EditClinicDashboard(superadmin);
                return;
            }

            Console.WriteLine("" 
                + PrintStatements.changableFields +
                PrintStatements.clinicNameArrow + obj.clinicName +
                PrintStatements.description + obj.description +
                PrintStatements.verificationStatusShow+ obj.isverified +
                PrintStatements.goToBack);

        label: Console.WriteLine(PrintStatements.chooseOption);
            EditClinic pressedKey;
            try
            {
                pressedKey = (EditClinic)Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine(PrintStatements.numericEntryOnly);
                goto label;
            }
            switch (pressedKey)
            {
                case EditClinic.Email:
                    var newClinicName = InputTaker.ClinicNameInput(PrintStatements.clinicNamePrint);
                    obj.clinicName = newClinicName;
                    break;

                case EditClinic.Description:
                    var description = InputTaker.ClinicDescriptionInput(PrintStatements.clinicDescriptionPrint);
                    obj.description = description;
                    break;

                case EditClinic.VerificationStatus:
                    Console.WriteLine(PrintStatements.enterToChange);
                    var pre = Console.ReadLine();
                    if(pre=="1")
                    obj.isverified = !obj.isverified;
                    break;

                case EditClinic.GoBack:
                     StartSuperAdminView(superadmin);
                    return;

                default:
                    Console.WriteLine(PrintStatements.choiceCorrectlyPrint);
                    goto label;
                    
            }
           
            if (clinicController.UpdateClinic(obj))
            {
                Console.WriteLine(PrintStatements.updateSucessFully);

            }
            else
            {
                Console.WriteLine(PrintStatements.someThingWentWrong);
            }

           
        }


         void DeleteAnyClinic(User superadmin)
        {
            var userName =InputTaker.UserNameInput(PrintStatements.wantToChangeClinic);
            Clinic obj = clinicController.GetClinicByClinicName(userName);
            if (obj == null)
            {
                Console.WriteLine(PrintStatements.erroruserNamePrint);
                DeleteAnyClinic(superadmin); 
                return;
               
            }
            else
            {
                if(clinicController.DeleteClinic(obj))
                {
                    Console.WriteLine(PrintStatements.deleteClinicArrow + obj.clinicName + PrintStatements.sucessful);
                }

            }

        }

        void AddMoreAdmin(User superadmin)
        {
            User user = RegistrationFoam.GetUserDetails(0);

            if (superAdminController.AddNewAdmin(user))
                Console.WriteLine(PrintStatements.newAdminAdded);
            else
            {
                Console.WriteLine(PrintStatements.someThingWentWrong);
            }

        }

        void LogOut(User superadmin)
        {
            superadmin = null;
            Program.StartApp();
        }

    }
}
