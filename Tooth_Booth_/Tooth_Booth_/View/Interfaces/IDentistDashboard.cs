using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.Controller.Interfaces;
using Tooth_Booth_.models;

namespace Tooth_Booth_.View.Interfaces
{
    internal interface IDentistDashboard
    {
        IDentistController dentistController { get; set; }
        public IAppointmentControllerForDentist appointmentController { get; set; }
        void DentistDashboardView(User dentist);
    }
}