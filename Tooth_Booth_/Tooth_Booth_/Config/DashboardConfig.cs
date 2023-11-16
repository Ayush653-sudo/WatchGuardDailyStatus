using Tooth_Booth_.View;
using Tooth_Booth_.View.Interfaces;

namespace Tooth_Booth_.Config
{
    static class DashboardConfig
    {

        public static IClinicAdminDashboard GetClinicAdminDashboard()
        {
            return new ClinicAdminDashboard(ControllerConfig.GetDentistControllerForClinicAdmin());
        }


        public static IDentistDashboard GetDentistDashboard()
        {
            return new DentistDashboard(ControllerConfig.GetDentistControllerForDentist(),ControllerConfig.GetAppointmentControllerForDentist());
        }

        public static IPatientDashboard GetPatientDashboard()
        {
            return new PatientDashboard(ControllerConfig.GetAppointmentController(),ControllerConfig.GetClinicControllerForPatient(),ControllerConfig.GetDentistControllerForPatient());
        }

        public static ISuperAdminView GetSuperAdminView()
        {
            return new SuperAdminView(ControllerConfig.GetSuperAdminController(),ControllerConfig.GetClinicControllerForSuperAdmin());
        }

    }
}
