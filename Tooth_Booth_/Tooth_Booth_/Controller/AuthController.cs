using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoothTooth_Booth_.View;
using Tooth_Booth_.common;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.Controller
{


    interface IAuthController
    {
        void LogIn();
        void SignUp();
    }

   public class AuthController:IAuthController
    {
   
        DBController dbController=new DBController(new DBHandler());
        
        public void LogIn()
        {
           
            AuthDashboard authDashboard=new AuthDashboard();
            Dictionary<string, string> logInCred=authDashboard.LogInView();

            Object userObj=DBController.handler.GetUserFromDB(logInCred);
            if(userObj==null)
            {
                Message.Invalid("Please Enter Correct Credentials No User Found");
                return;
            }
          
            if (userObj is Clinic)
            {
                Clinic obj = (Clinic)userObj;
                ClinicAdminDashboard clinicAdminDashboard=new ClinicAdminDashboard(new ClinicController());
                clinicAdminDashboard.StartClinicAdminDashboard(obj);
            }
            else if(userObj is Patient)
            {
                Patient obj = (Patient)userObj;
                PatientDashboard patientDashboard=new PatientDashboard(new PatientController());
                patientDashboard.PatientDashboardView(obj);


            }
            else if (userObj is Dentist)
            {
               Dentist obj = (Dentist)userObj;
                DentistDashboard dentistDashboard=new DentistDashboard(new DentistController());
                dentistDashboard.DentistDashboardView(obj);
            }

            else if(userObj is SuperAdmin)
            {
                SuperAdmin obj = (SuperAdmin)userObj;
                SuperAdminView SuperAdminDashboard = new SuperAdminView(new SuperAdminController());
                SuperAdminDashboard.StartSuperAdminView(obj);
            }


            

        }
        public void SignUp()
        {
          
            AuthDashboard authdashboard=new AuthDashboard();
            dynamic obj=authdashboard.RegistrationView();
            if (obj.userType == UserType.clinicAdmin)
            {
                if (DBController.handler.AddEntryAtDB(obj))
                    Message.Status("You Have Registered Sucessfully");
                else
                    Message.Invalid("Something Went Wrong");

            }
            else if(obj.userType == UserType.Patient)
            {
                if(DBController.handler.AddEntryAtDB(obj))
                   
                        Message.Status("You Have Registered Sucessfully");
                    else
                        Message.Invalid("Something Went Wrong");
            }

        }
    }
}
