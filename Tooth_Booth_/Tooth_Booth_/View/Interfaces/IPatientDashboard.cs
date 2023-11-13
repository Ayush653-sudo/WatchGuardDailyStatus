using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.Controller.Interfaces;
using Tooth_Booth_.models;

namespace Tooth_Booth_.View.Interfaces
{
    internal interface IPatientDashboard
    {
        IAppointmentControllerForPatient appointmentController { get; set; }
        IClinicController clinicController { get; set; }
        void CancelAppointmentByIdView(User patient);
        void LogOut(User patient);
        void PatientBookAppointmentView(User patient);
        void PatientDashboardView(User patient);
        void ViewAllAppointment(User patient);
    }
}