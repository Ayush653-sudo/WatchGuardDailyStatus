using ThoothTooth_Booth_.View;
using Tooth_Booth_.Controller;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.Controller.Interfaces;

namespace Tooth_Booth_.Config
{
    static class ControllerConfig
    {

        public static IAuthController GetAuthController()
        {
            return new AuthController(new AuthDashboard());
        }
        
        public static IClinicControllerForSuperAdmin GetClinicControllerForSuperAdmin()
        {
            return new ClinicController();
        }
        public static IClinicControllerForPatient GetClinicControllerForPatient()
        {
            return new ClinicController();
        }

        public static IDentistControllerForClinicAdmin GetDentistControllerForClinicAdmin()
        {
            return new DentistController();
        }

        public static IDentistControllerForDentist GetDentistControllerForDentist()
        {
            return new DentistController();
        }

        public static IDentistControllerForPatient GetDentistControllerForPatient()
        {
            return new DentistController();
        }


        public static ISuperAdminController GetSuperAdminController()
        {
            return new SuperAdminController();
        }

        public static IAppointmentControllerForPatient GetAppointmentController()
        {
            return new AppointmentController();
        }

        public static IAppointmentControllerForDentist GetAppointmentControllerForDentist()
        {
            return new AppointmentController();
        }


    }
}
