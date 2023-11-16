

using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.DatabaseHandler
{
   sealed public class AppointmentDBHandler:DBHandler
    {
        public List<Appointment> listOfAppointment { get; set; }

        public string appointmentPath { set; get; } = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Appointment.json";
        static AppointmentDBHandler _handler = null;
        
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
        public static AppointmentDBHandler handler
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
    }
}
