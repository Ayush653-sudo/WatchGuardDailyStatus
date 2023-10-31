using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ThoothTooth_Booth_.View;
using Tooth_Booth_.common;
using Tooth_Booth_.Controller;
using Tooth_Booth_.models;

namespace Tooth_Booth_.View
{
    public class SuperAdminView
    {
        ISuperAdminController superAdminController;

       internal SuperAdminView(ISuperAdminController superAdminController)
        {
            this.superAdminController = superAdminController;
        }
        internal void StartSuperAdminView(SuperAdmin user)
        {

            while (true)
            {
                Common.SuperAdminStartView();

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
                            Console.WriteLine("Enter Choice Correctly");
                            break;

                    }
                }
                catch 
                {
                    Message.Invalid("Give Correct Input");

                }


            }


        }

        void ViewListOfAvailableClinic(SuperAdmin user)
        {
           List<Clinic>clinics= superAdminController.GeListOfClinic();

            if(clinics.Count==0)
            {
                Console.WriteLine("No Clinic Availabl");
            }
           
               Console.WriteLine("Following are the list of all clinic registeed at our website");

            foreach(var obj in clinics) 
            {
                
                Console.WriteLine("ClinicName:       -> " + obj.clinicName);
                Console.WriteLine("Description:      -> "+obj.description);
                Console.WriteLine("Clinic user Name: -> " + obj.userName);
                Console.WriteLine("City:             -> " + obj.clinicCity);
                Console.WriteLine("IsVerifired:      -> "+obj.isverified);

            }


        }

        internal void EditClinicDashboard(SuperAdmin superadmin)
        {

            clinicusername:Console.WriteLine("Enter Username of Clinic Whose Entry You want to change");
            var userName = Console.ReadLine()!.Trim();
            if(String.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Fields can't be null or empty");
                goto clinicusername;
            }
               Clinic obj=superAdminController.GetClinic(userName);
            if(obj==null)
            {
                Console.WriteLine("Kindly ReTry and enter correct userName");
                goto clinicusername;
            }

            Console.WriteLine("" +
                "You Could Only Change Following Fields:" +
                "\n 1)Email: " + obj.emailAddress +
                "\n 2)PhoneNumber : " + obj.phoneNumber +
                "\n 3)Description: " + obj.description +
                "\n 4)Verification Status: "+ obj.isverified +
                "\n 5)To Go Back ");

        label: Console.WriteLine("Enter Your Choice From Above Option");
            EditClinic pressedKey;
            try
            {
                pressedKey = (EditClinic)Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please Enter numeric Term");
                goto label;
            }
            switch (pressedKey)
            {
                case EditClinic.Email:
                 emailentry:   Console.WriteLine("Enter New Email Address");
                    var newEmail = Console.ReadLine()!.Trim();
                    obj.emailAddress = newEmail;
                    if (!Common.CheckEmail(newEmail))
                    {
                        Console.WriteLine("Please Enter A valid Email");
                        goto emailentry;
                    }
                    break;

                case EditClinic.PhoneNumber:
                 phoneretry:   Console.WriteLine("Enter New PhoneNumber");
                   var newPhoneNumber = Console.ReadLine()!.Trim();
                   bool isValidated = Common.hasnumber.IsMatch(newPhoneNumber);
                    if (!isValidated)
                    {
                        Console.WriteLine("Enter valid phone number");
                        goto phoneretry;
                    }
                    obj.phoneNumber = newPhoneNumber;
                    break;

                case EditClinic.Description:
                  clinicdescriptionretry:  Console.WriteLine("Enter New Description Of Your Clinic");
                    var description = Console.ReadLine()!.Trim();
                    if (Common.CountWords(description)<6)
                    {
                        Console.WriteLine("Description must contain Word more than 6 for description");
                        goto clinicdescriptionretry;
                    }
                    break;

                case EditClinic.VerificationStatus:
                    Console.WriteLine("Enter 1 To Change Verification status else any other key");
                    var pre = Console.ReadLine();
                    if(pre=="1")
                    obj.isverified = !obj.isverified;
                    break;

                case EditClinic.GoBack:
                     StartSuperAdminView(superadmin);
                    return;

                default:
                    Console.WriteLine("Please Choose Correct Option and Retry");
                    goto label;
                    
            }
           
            if (superAdminController.UpdateClinic(obj))
            {
                Console.WriteLine("----You have sucessfully updated the details-----");

            }
            else
            {
                Console.WriteLine("SomeThing Went Wrong Please Try Again");
            }

           
        }


        void DeleteAnyClinic(SuperAdmin superadmin)
        {

            usernameentry: Console.WriteLine("Enter Username of Clinic Whose Entry You want to change");
            var userName = Console.ReadLine()!.Trim();
            if(String.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Empty Fieldsare not allowed");
                goto usernameentry;
            }
            Clinic obj = superAdminController.GetClinic(userName);
            if (obj == null)
            {
                Console.WriteLine("Kindly ReTry and enter correct userName");
                goto usernameentry;
               
            }
            else
            {
                if(superAdminController.DeleteClinic(userName))
                {
                    Console.WriteLine("We Have Deleted Clininc:->" + obj.clinicName + "Sucessfully");
                }


            }

        }

        void AddMoreAdmin(SuperAdmin superadmin)
        {
            User user = RegistrationFoam.GetUserCommonDetails(0);

            if (superAdminController.AddNewAdmin(user))
                Console.WriteLine("New Admin Added SucessFully");
            else
            {
                Console.WriteLine("Something Went Wront");
            }

        }

        void LogOut(SuperAdmin superadmin)
        {
            superadmin = null;
            Program.StartApp();
        }

    }
}
