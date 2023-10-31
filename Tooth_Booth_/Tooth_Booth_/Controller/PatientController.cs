
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.Controller
{
    interface IPatientController
    {
        bool BookNewAppointment(Appointment appointment);
        List<Appointment> GetPersonAllAppointment(Patient patient);
        bool cancleAppointById(Patient patient,int id);
        List<String> GetListOFClinic(string cityName);
        Dictionary<String, String> GetDentistList(string stringName);


    }
    class PatientController:IPatientController
    {

        
        public bool BookNewAppointment(Appointment appointment)
        {
            int index= DBController.handler.listOfDentist.FindIndex((obj) => obj.userName == appointment.doctorUserName);
            
            if (DBController.handler.AddEntryAtDB(appointment))
            {
                DBController.handler.listOfDentist[index].maxAppointment -= 1;
                if(DBController.handler.UpdateEntryAtDB<Dentist>(DBController.handler.dentistPath, DBController.handler.listOfDentist))
                return true;
                else
                    DBController.handler.listOfDentist[index].maxAppointment += 1 ;


            }
            return false;
        }

        public List<Appointment> GetPersonAllAppointment(Patient patient)
        {
            List<Appointment> appointments = new List<Appointment>();

            appointments = DBController.handler.listOfAppointment.FindAll((obj) => obj.patientsUserName == patient.userName);

            return appointments;
        }

        public bool cancleAppointById(Patient patient,int id)
        {
            int index = DBController.handler.listOfAppointment.FindIndex((obj) => (obj.appointmentId == id && obj.patientsUserName == patient.userName &&obj.appointmentDate==DateTime.Today));


            if (index == -1)
                return false;
            if (DBController.handler.listOfAppointment[index].prescription.Length > 0)
            {
                Message.Invalid("You Have Already Taken Prescription by dentist");
                return false;
            }
            var doctorUserName = DBController.handler.listOfAppointment[index].doctorUserName;
            DBController.handler.listOfAppointment.RemoveAt(index);
            if (DBController.handler.UpdateEntryAtDB<Appointment>(DBController.handler.appointmentPath, DBController.handler.listOfAppointment))
            {
               
                int doctorIndex = DBController.handler.listOfDentist.FindIndex((obj)=>obj.userName== doctorUserName);
                DBController.handler.listOfDentist[doctorIndex].maxAppointment += 1;

                if (DBController.handler.UpdateEntryAtDB<Dentist>(DBController.handler.dentistPath, DBController.handler.listOfDentist))
                    return true;
                else
                    return false;

            }
            else
                return false;
        }
        public List<String> GetListOFClinic(string cityName)
        {
            List<String> list = new List<String>();
            list = DBController.handler.listOfClinic.FindAll((obj) => obj.clinicCity == cityName && obj.isverified == true).Select((obj) => obj.userName).ToList();
            return list;

        }

        public Dictionary<String, String> GetDentistList(string clinicName)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var obj in DBController.handler.listOfDentist)
            {
                if (obj.clinicName == clinicName && obj.availability == true&&obj.maxAppointment>0)
                {
                    dict[obj.userName] = obj.category.ToString();
                }
            }
            return dict;
        }


    }
}
