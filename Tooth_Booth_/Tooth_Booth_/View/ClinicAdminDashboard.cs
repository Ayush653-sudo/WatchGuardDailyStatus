using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoothTooth_Booth_.View;
using Tooth_Booth_.common;
using Tooth_Booth_.Controller;
using Tooth_Booth_.database;
using Tooth_Booth_.models;

namespace Tooth_Booth_.View
{
     class ClinicAdminDashboard
    {
        IClinicController clinicController;
        public ClinicAdminDashboard(IClinicController clinicController)
        {
            this.clinicController= clinicController;
        }
        public  void StartClinicAdminDashboard(Clinic obj)
        {

            while (true)
            {
                Console.WriteLine("Welcome" + " " + obj.userName );

                Common.ClinicStartView();

                try
                {
                    var pressedKey = (ClinicStarter)Convert.ToInt32(Console.ReadLine());
                    switch (pressedKey)
                    {
                        case ClinicStarter.RegisterDentist:
                            DentistRegistrationDashboard(obj);
                            break;

                        case ClinicStarter.DeleteDentist: DeleteDentistAtClinic(obj); 
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
                catch 
                {
                    Message.Invalid("Something bad happend!!!");
                }
            }
            
        }
        public void DeleteDentistAtClinic(Clinic obj)
        {
            Console.WriteLine("Enter Username of Dentist Whose Entry You want to change");
            var userName = Console.ReadLine()!.Trim();

            if (clinicController.DeleteDentist(obj,userName))
                Console.WriteLine("you have Sucessfully Deleted The Dentist!!");
            else
            {
                Console.WriteLine("Something ent wrong!!!!");
            }


        }

        public  void DentistRegistrationDashboard(Clinic obj)
        {
            Console.WriteLine("----------------------------Enter Detail Of Dentist--------------------------");

            User user = RegistrationFoam.GetUserCommonDetails(2);
        dentistcategory: Console.WriteLine("Choose Dentist Category.");
            Common.ClinicCommon();   
            DentistCategory pressedKey;
            try
            {
                pressedKey=(DentistCategory)Convert.ToInt32(Console.ReadLine());
            }
            catch 
            {
                Message.Invalid("Please Enter The Key In Numeric Term");
                goto dentistcategory;
            }
            DentistCategory category= DentistCategory.GeneralDentist;
            switch (pressedKey)
            {
                case DentistCategory.GeneralDentist: category = DentistCategory.GeneralDentist;
                    break;
                case DentistCategory.Pedodontist:category = DentistCategory.Pedodontist;
                    break;
                case DentistCategory.Orthodontist:category = DentistCategory.Orthodontist;
                    break;
                case DentistCategory.Periodontis:category = DentistCategory.Periodontis;
                    break;
                case DentistCategory.Endodontist:category = DentistCategory.Endodontist;
                    break;
                case DentistCategory.OralPathologists:category = DentistCategory.OralPathologists;
                    break;
                case DentistCategory.Prosthodontist:category = DentistCategory.Prosthodontist;
                    break;
                default: Console.WriteLine("Choose Correct Key");
                goto dentistcategory;

            }
          
            Dentist newDentist=new Dentist(user,obj.userName,category,0);
            if (clinicController.RegisterNewDentist(newDentist))
                Console.WriteLine("You have registered dentist sucessfully!!");
            else
            {
                Console.WriteLine("Please try again ");
                return;
            }
         

        }
        public  void ShowDentistAtClinic(Clinic obj)
        {
            List<Dentist> listOfDentist =clinicController.GetDentistAtClinic(obj);
            if(listOfDentist.Count == 0)
            {
                Console.WriteLine("No Dentist Available At Your Clinic!!");
                return;
            }

            Console.WriteLine("Following are the Dentist Available At Your Clinic: ");
            foreach(Dentist d in listOfDentist)
            {
               Console.WriteLine("------------------------------------------------------------------------------");

               Console.WriteLine("Dentist Username:-> "+d.userName + " Has Specialization in -> " + d.category);

            }
               Console.WriteLine("------------------------------------------------------------------------------");


        }       
    }
}
