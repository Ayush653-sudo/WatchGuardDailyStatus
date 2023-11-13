using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.models;

namespace Tooth_Booth_.View.Interfaces
{
    internal interface IClinicAdminDashboard
    {

        IDentistController dentistController { get; set; }
        void StartClinicAdminDashboard(Clinic obj);
    }
}