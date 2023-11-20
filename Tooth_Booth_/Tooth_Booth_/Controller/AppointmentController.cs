using Tooth_Booth_.Controller.Interfaces;
using Tooth_Booth_.database;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.Controller
{
    public class AppointmentController : IAppointmentControllerForPatient, IAppointmentControllerForDentist
    {

        IDBHandler<Dentist> dentistDBHandler;
        IDBHandler<Appointment> appointmentDBHandler;
        public AppointmentController(IDBHandler<Dentist> dentistDBHandler, IDBHandler<Appointment> appointmetnDBHandler)
        {
            this.dentistDBHandler = dentistDBHandler;
            this.appointmentDBHandler = appointmetnDBHandler;

        }

        public List<Appointment> GetAppointmentByDates(string doctorUserName, DateTime dateTime)
        {

            List<Appointment> listOfAppointment = appointmentDBHandler.GetList();
            return listOfAppointment.FindAll((obj) => obj.appointmentDate == dateTime && doctorUserName == obj.doctorUserName);
        }
        public Appointment GetAppointmentById(string doctorUserName, int id)
        {

            List<Appointment> listOfAppointment =  appointmentDBHandler.GetList();
            return listOfAppointment.Find((obj) => obj.appointmentId == id && doctorUserName == obj.doctorUserName)!;

        }

        public bool AddPrescriptionToAppointment(Appointment appointment)
        {

            List<Appointment> listOfAppointment = appointmentDBHandler.GetList();
            int index = listOfAppointment.FindIndex((obj) => obj.appointmentId == appointment.appointmentId);
            listOfAppointment[index].prescription = appointment.prescription;

            if (appointmentDBHandler.Update(listOfAppointment[index]))
                return true;
            else
                return false;


        }
        public bool BookNewAppointment(Appointment appointment)
        {
            List<Dentist> listOfDentist = dentistDBHandler.GetList();
            int index =listOfDentist.FindIndex((obj) => obj.userName == appointment.doctorUserName);

            if (appointmentDBHandler.Add(appointment))
            {
                listOfDentist[index].maxAppointment -= 1;
                if (dentistDBHandler.Update(listOfDentist[index]))
                    return true;
                

            }
            return false;
        }
        public List<Appointment> GetAllAppointmentByUsername(string userName)
        {
            
           List<Appointment> appointments = appointmentDBHandler.GetList().FindAll((obj) => obj.patientsUserName == userName);

            return appointments;
        }

        public bool CancleAppointById(string userName, int id)
        {

            List<Appointment> listOfAppointment = appointmentDBHandler.GetList();
            int index = listOfAppointment.FindIndex((obj) => (obj.appointmentId == id && obj.patientsUserName == userName && obj.appointmentDate == DateTime.Today));

            if (index == -1)
                return false;
            if (listOfAppointment[index].prescription.Length > 0)
            {
                Message.Invalid("You Have Already Taken Prescription by dentist");
                return false;
            }
            var doctorUserName =listOfAppointment[index].doctorUserName;
            List<Dentist> listOfDentist = dentistDBHandler.GetList();
            if (appointmentDBHandler.Delete(listOfAppointment[index]))
            {

                int doctorIndex =listOfDentist.FindIndex((obj) => obj.userName == doctorUserName);
                listOfDentist[doctorIndex].maxAppointment += 1;

                if (dentistDBHandler.Update(listOfDentist[doctorIndex]))
                    return true;
                else
                    return false;

            }
            else
                return false;
        }

    }
}
