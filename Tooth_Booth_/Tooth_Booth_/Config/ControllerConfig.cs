using ThoothTooth_Booth_.View;
using Tooth_Booth_.Controller;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.Controller.Interfaces;
using Tooth_Booth_.DatabaseHandler;

namespace Tooth_Booth_.Config
{
    public static class ControllerConfig
    {

        public static IAuthController GetAuthController()
        {
            return new AuthController(new AuthDashboard(),UserDBHandler.handler,ClinicDBHandler.handler);
        }
        
        public static IClinicControllerForSuperAdmin GetClinicControllerForSuperAdmin()
        {
            return new ClinicController(DentistDBHandler.handler,ClinicDBHandler.handler,UserDBHandler.handler);
        }
        public static IClinicControllerForPatient GetClinicControllerForPatient()
        {
            return new ClinicController(DentistDBHandler.handler, ClinicDBHandler.handler, UserDBHandler.handler);
        }

        public static IDentistControllerForClinicAdmin GetDentistControllerForClinicAdmin()
        {
            return new DentistController(DentistDBHandler.handler,UserDBHandler.handler,AppointmentDBHandler.handler);
        }

        public static IDentistControllerForDentist GetDentistControllerForDentist()
        {
            return new DentistController(DentistDBHandler.handler,UserDBHandler.handler,AppointmentDBHandler.handler);
        }

        public static IDentistControllerForPatient GetDentistControllerForPatient()
        {
            return new DentistController(DentistDBHandler.handler, UserDBHandler.handler, AppointmentDBHandler.handler);
        }


        public static ISuperAdminController GetSuperAdminController()
        {
            return new SuperAdminController(UserDBHandler.handler);
        }

        public static IAppointmentControllerForPatient GetAppointmentController()
        {
            return new AppointmentController(DentistDBHandler.handler,AppointmentDBHandler.handler);
        }

        public static IAppointmentControllerForDentist GetAppointmentControllerForDentist()
        {
            return new AppointmentController(DentistDBHandler.handler,AppointmentDBHandler.handler);
        }


    }
}
