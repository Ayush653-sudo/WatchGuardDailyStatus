
using Tooth_Booth_.common;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.DatabaseHandler
{
   sealed public class ClinicDBHandler:DBHandler
    {


        public List<Clinic> listOfClinic;

        public string clinicPath = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Clinic.json";
        static ClinicDBHandler _handler = null;
   
      private ClinicDBHandler()
        {

            listOfClinic = new List<Clinic>();
            try
            {
                string clinicFileContent = File.ReadAllText(clinicPath);
                if (!string.IsNullOrEmpty(clinicFileContent))
                    listOfClinic = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Clinic>>(clinicFileContent)!;

            }
            catch (Exception ex) 
            {

                ExceptionDBHandler.handler.AddEntryToFile( ex.ToString());
                Message.Invalid(PrintStatements.someThingWentWrong);

            }

        }
        public static ClinicDBHandler handler
        {
            get
            {
                if (_handler == null)
                {
                    _handler = new ClinicDBHandler();
                }
                return _handler;
            }
        }

    }
}
