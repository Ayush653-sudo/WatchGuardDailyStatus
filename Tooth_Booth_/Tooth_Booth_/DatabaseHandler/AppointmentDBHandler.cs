

using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.DatabaseHandler
{
   sealed public class AppointmentDBHandler:DBHandler,IDBHandler<Appointment>
    {
        List<Appointment> listOfAppointment;
        string appointmentPath { set; get; } = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Appointment.json";
        static IDBHandler<Appointment> _handler = null;
        
        private AppointmentDBHandler()
        {

            listOfAppointment = new List<Appointment>();
            try
            {
                string appointmentFileContent = File.ReadAllText(appointmentPath);
                if(!string.IsNullOrEmpty(appointmentFileContent)) 

                listOfAppointment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Appointment>>(appointmentFileContent)!;

            }
            catch(Exception ex) 
            {

                ExceptionDBHandler.handler.AddEntryToFile(ex.ToString());
                Message.Invalid("SomeThing Went Wrong With Files");

            }

        }
        public static IDBHandler<Appointment> handler
        {
            get
            {
                if (_handler == null)
                {
                    _handler = new AppointmentDBHandler();
                }
                return _handler;
            }
        }
        public List<Appointment> GetList()
        {
            return listOfAppointment;
        }
        public bool Update(Appointment updatedAppointment)
        {
            int index = listOfAppointment.FindIndex((obj) => obj.appointmentId.Equals(updatedAppointment.appointmentId));
            listOfAppointment[index] = updatedAppointment;
            return UpdateEntryAtDB<Appointment>(appointmentPath, listOfAppointment);
        }
        public bool Delete(Appointment appointment)
        {
            int index = listOfAppointment.FindIndex((obj) => obj.appointmentId.Equals(appointment.appointmentId));
            listOfAppointment.RemoveAt(index);
            return UpdateEntryAtDB<Appointment>(appointmentPath, listOfAppointment);
        }

        public bool Add(Appointment appointment)
        {
            listOfAppointment.Add(appointment);
            return UpdateEntryAtDB<Appointment>(appointmentPath, listOfAppointment);
        }
    }
}
