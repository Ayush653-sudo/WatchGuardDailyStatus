
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.DatabaseHandler
{
   sealed public class ClinicDBHandler:DBHandler
    {


        public List<Clinic> listOfClinic { get; set; }

        public string clinicPath { set; get; } = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Clinic.json";
        static ClinicDBHandler _handler = null;
   
      private ClinicDBHandler()
        {



            listOfClinic = new List<Clinic>();
            try
            {
                string clinicFileContent = File.ReadAllText(clinicPath);

                listOfClinic = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Clinic>>(clinicFileContent)!;

            }
            catch (Exception ex) 
            {

                ExceptionDBHandler.handler.AddEntryAtDB<String>(ExceptionDBHandler.handler.ExceptionPath, ex.ToString(), ExceptionDBHandler.handler.ListOfException);
                Message.Invalid("SomeThing Went Wrong With Files");

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
