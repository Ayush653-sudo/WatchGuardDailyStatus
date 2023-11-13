using Tooth_Booth_.models;

namespace Tooth_Booth_.Controller.Interfaces
{
    public interface IAppointmentControllerForDentist
    {

        bool AddPrescriptionToAppointment(Appointment appointment);
        bool BookNewAppointment(Appointment appointment);
        List<Appointment> GetAppointmentByDates(string userName, DateTime dateTime);
        Appointment GetAppointmentById(string userName, int id);
    }
}