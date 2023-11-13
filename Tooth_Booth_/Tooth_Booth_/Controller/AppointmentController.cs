using Tooth_Booth_.Controller.Interfaces;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.Controller
{
    public class AppointmentController : IAppointmentControllerForPatient, IAppointmentControllerForDentist
    {

        public List<Appointment> GetAppointmentByDates(string userName, DateTime dateTime)
        {

            return AppointmentDBHandler.handler.listOfAppointment.FindAll((obj) => obj.appointmentDate == dateTime && userName == obj.doctorUserName);
        }
        public Appointment GetAppointmentById(string userName, int id)
        {

            return AppointmentDBHandler.handler.listOfAppointment.Find((obj) => obj.appointmentId == id && userName == obj.doctorUserName)!;

        }

        public bool AddPrescriptionToAppointment(Appointment appointment)
        {

            int index = AppointmentDBHandler.handler.listOfAppointment.FindIndex((obj) => obj.appointmentId == appointment.appointmentId);
            AppointmentDBHandler.handler.listOfAppointment[index] = appointment;

            if (AppointmentDBHandler.handler.UpdateEntryAtDB<Appointment>(AppointmentDBHandler.handler.appointmentPath, AppointmentDBHandler.handler.listOfAppointment))
                return true;
            else
                return false;


        }
        public bool BookNewAppointment(Appointment appointment)
        {
            int index = DentistDBHandler.handler.listOfDentist.FindIndex((obj) => obj.userName == appointment.doctorUserName);

            if (AppointmentDBHandler.handler.AddEntryAtDB<Appointment>(AppointmentDBHandler.handler.appointmentPath, appointment, AppointmentDBHandler.handler.listOfAppointment))
            {
                DentistDBHandler.handler.listOfDentist[index].maxAppointment -= 1;
                if (DentistDBHandler.handler.UpdateEntryAtDB<Dentist>(DentistDBHandler.handler.dentistPath, DentistDBHandler.handler.listOfDentist))
                    return true;
                else
                    DentistDBHandler.handler.listOfDentist[index].maxAppointment += 1;


            }
            return false;
        }
        public List<Appointment> GetAllAppointmentByUsername(string userName)
        {
            List<Appointment> appointments = new List<Appointment>();

            appointments = AppointmentDBHandler.handler.listOfAppointment.FindAll((obj) => obj.patientsUserName == userName);

            return appointments;
        }

        public bool cancleAppointById(string userName, int id)
        {
            int index = AppointmentDBHandler.handler.listOfAppointment.FindIndex((obj) => (obj.appointmentId == id && obj.patientsUserName == userName && obj.appointmentDate == DateTime.Today));


            if (index == -1)
                return false;
            if (AppointmentDBHandler.handler.listOfAppointment[index].prescription.Length > 0)
            {
                Message.Invalid("You Have Already Taken Prescription by dentist");
                return false;
            }
            var doctorUserName = AppointmentDBHandler.handler.listOfAppointment[index].doctorUserName;
            AppointmentDBHandler.handler.listOfAppointment.RemoveAt(index);
            if (AppointmentDBHandler.handler.UpdateEntryAtDB<Appointment>(AppointmentDBHandler.handler.appointmentPath, AppointmentDBHandler.handler.listOfAppointment))
            {

                int doctorIndex = DentistDBHandler.handler.listOfDentist.FindIndex((obj) => obj.userName == doctorUserName);
                DentistDBHandler.handler.listOfDentist[doctorIndex].maxAppointment += 1;

                if (DentistDBHandler.handler.UpdateEntryAtDB<Dentist>(DentistDBHandler.handler.dentistPath, DentistDBHandler.handler.listOfDentist))
                    return true;
                else
                    return false;

            }
            else
                return false;
        }

    }
}
