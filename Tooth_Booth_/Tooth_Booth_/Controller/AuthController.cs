
using ThoothTooth_Booth_.View;
using Tooth_Booth_.common;
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.Config;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.models;
using Tooth_Booth_.View;
using Tooth_Booth_.View.Interfaces;

namespace Tooth_Booth_.Controller
{




    public class AuthController : IAuthController
    {
        IAuthDashboard authDashboard;
        public AuthController(IAuthDashboard authDashboard)
        {
            this.authDashboard = authDashboard;
        }


        public User GetUserFromDB(Dictionary<string, string> logInCred)
        {
            return UserDBHandler.handler.listOfUser.Find((obj) => obj.userName == logInCred["username"] && obj.password == logInCred["password"])!;

        }
        public static bool  isPresentEarlier(string userName)
        {
            if (UserDBHandler.handler.listOfUser.FindIndex((obj) => obj.userName == userName) != -1)
                return true;
            return false;

        }

        public void LogIn()
        {           
            Dictionary<string, string> logInCred = authDashboard.LogInView();

            User userObj = GetUserFromDB(logInCred);
            if (userObj == null)
            {
                Message.Invalid("Please Enter Correct Credentials No User Found");
                return;
            }

            if (userObj.userType==UserType.clinicAdmin)
            {
              
                IClinicAdminDashboard clinicAdminDashboard = DashboardConfig.GetClinicAdminDashboard();
                Clinic clinic=ClinicDBHandler.handler.listOfClinic.Find((obj)=>obj.listOFClinicAdmin.Contains(userObj.userName))!;
                clinicAdminDashboard.StartClinicAdminDashboard(clinic);
            }
            else if (userObj.userType == UserType.Patient)
            {
                
                IPatientDashboard patientDashboard = DashboardConfig.GetPatientDashboard();
                patientDashboard.PatientDashboardView(userObj);

            }
            else if (userObj.userType == UserType.Dentist)
            {
                
                IDentistDashboard dentistDashboard = DashboardConfig.GetDentistDashboard();
                dentistDashboard.DentistDashboardView(userObj);
            }

            else if (userObj.userType == UserType.SuperAdmin)
            {
             
                ISuperAdminView SuperAdminDashboard = DashboardConfig.GetSuperAdminView();
                SuperAdminDashboard.StartSuperAdminView(userObj);
            }

        }
        public void SignUp()
        {

            User obj = authDashboard.RegistrationView();
            if (!isPresentEarlier(obj.userName))
            {
                if (UserDBHandler.handler.AddEntryAtDB<User>(UserDBHandler.handler.userPath, obj, UserDBHandler.handler.listOfUser))
                {
                    if (obj.userType == UserType.clinicAdmin)
                    {
                        Clinic clinicObj = RegistrationFoam.ClinicRegistrationDetails(obj.userName);
                        int index=ClinicDBHandler.handler.listOfClinic.FindIndex((obj)=>obj.clinicName==clinicObj.clinicName);
                        if(index==-1)
                        {
                            Message.Invalid("Clinic with this clinic name is already present");
                            UserDBHandler.handler.listOfUser.Remove(obj);
                            UserDBHandler.handler.AddEntryAtDB<User>(UserDBHandler.handler.userPath, obj, UserDBHandler.handler.listOfUser);
                            return;
                        }

                        if (ClinicDBHandler.handler.AddEntryAtDB<Clinic>(ClinicDBHandler.handler.clinicPath, clinicObj, ClinicDBHandler.handler.listOfClinic))
                            Message.Status("You Have Registered Sucessfully");
                        else
                        {
                            Message.Invalid(PrintStatements.someThingWentWrong);
                            UserDBHandler.handler.listOfUser.Remove(obj);
                            UserDBHandler.handler.AddEntryAtDB<User>(UserDBHandler.handler.userPath, obj, UserDBHandler.handler.listOfUser);
                        }

                    }
                    else if (obj.userType == UserType.Patient)
                    {
                        Message.Status("You have successfully registered as a patient");
                    }
                }
            }
            else
            {
                Message.Invalid("username is already exists Try Again with different userName");

            }

        }
    }
}
