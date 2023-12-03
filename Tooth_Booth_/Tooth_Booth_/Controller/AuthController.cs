
using ThoothTooth_Booth_.View;
using Tooth_Booth_.common;
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.Config;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;
using Tooth_Booth_.View.Interfaces;

namespace Tooth_Booth_.Controller
{




    public class AuthController : IAuthController
    {
        IAuthDashboard _authDashboard;
        IDBHandler<User> userDBHandler;
        IDBHandler<Clinic> clinicDBHandler;
        public AuthController(IAuthDashboard authDashboard, IDBHandler<User> userDBHandler, IDBHandler<Clinic> clinicDBHandler)
        {
            this._authDashboard = authDashboard;
            this.userDBHandler = userDBHandler;
            this.clinicDBHandler = clinicDBHandler;
        }


        public User GetUserFromDB(Dictionary<string, string> logInCred)
        {
            List<User> listOfUser = userDBHandler.GetList();
            return listOfUser.Find((obj) => obj.userName == logInCred["username"] && obj.password == logInCred["password"])!;

        }
        public bool IsPresentEarlier(string userName)
        {

            List<User> listOfUser = userDBHandler.GetList();
            if (listOfUser.FindIndex((obj) => obj.userName == userName) != -1)
                return true;
            return false;

        }

        public void LogIn()
        {           
            Dictionary<string, string> logInCred = _authDashboard.LogInView();

            User userObj = GetUserFromDB(logInCred);
            if (userObj == null)
            {
                Message.Invalid("\nPlease Enter Correct Credentials No User Found");
                return;
            }

            if (userObj.userType==UserType.clinicAdmin)
            {
              
                IClinicAdminDashboard clinicAdminDashboard = DashboardConfig.GetClinicAdminDashboard();
                Clinic clinic=clinicDBHandler.GetList().Find((obj)=>obj.listOFClinicAdmin.Contains(userObj.userName))!;
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

            User obj = _authDashboard.RegistrationView();
            if (!IsPresentEarlier(obj.userName))
            {
                if (userDBHandler.Add(obj))
                {
                    if (obj.userType == UserType.clinicAdmin)
                    {
                        Clinic clinicObj = RegistrationFoam.ClinicRegistrationDetails(obj.userName);
                        int index=clinicDBHandler.GetList().FindIndex((obj)=>obj.clinicName==clinicObj.clinicName);
                        if(index!=-1)
                        {
                            Message.Invalid("Clinic with this clinic name is already present");
                            userDBHandler.Delete(obj);
                            return;
                        }

                        if (clinicDBHandler.Add(clinicObj))
                            Message.Status("You Have Registered Sucessfully");
                        else
                        {
                            Message.Invalid(PrintStatements.someThingWentWrong);
                            userDBHandler.Delete(obj);
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
