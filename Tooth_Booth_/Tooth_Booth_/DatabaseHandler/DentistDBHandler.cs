
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.DatabaseHandler
{
   sealed public class DentistDBHandler:DBHandler
    {
        public List<Dentist> listOfDentist { get; set; }
           
        public string dentistPath { set; get; } = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Dentist.json";
        static DentistDBHandler _handler = null;
        
        private DentistDBHandler()
        {

          
           
            listOfDentist = new List<Dentist>();
            try
            {
                string dentistFileContent = File.ReadAllText(dentistPath);
               
                listOfDentist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dentist>>(dentistFileContent)!;

            }
            catch(Exception ex) {


                ExceptionDBHandler.handler.AddEntryAtDB<String>(ExceptionDBHandler.handler.ExceptionPath, ex.ToString(), ExceptionDBHandler.handler.ListOfException);
                Message.Invalid("SomeThing Went Wrong With Files");

            }

        }
        public static DentistDBHandler handler
        {
            get
            {
                if (_handler == null)
                {
                    _handler = new DentistDBHandler();
                }
                return _handler;
            }
        }
    }
}
