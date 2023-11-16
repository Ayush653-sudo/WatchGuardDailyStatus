
using Tooth_Booth_.common;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.DatabaseHandler
{
 sealed public class DentistDBHandler:DBHandler
    {
        public List<Dentist> listOfDentist;
           
        public string dentistPath= @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Dentist.json";
        static DentistDBHandler _handler = null;
        
        private DentistDBHandler()
        {      
           
            listOfDentist = new List<Dentist>();
            try
            {
                string dentistFileContent = File.ReadAllText(dentistPath);

               if(!string.IsNullOrEmpty(dentistFileContent))
                listOfDentist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dentist>>(dentistFileContent)!;

            }
            catch(Exception ex) {


                ExceptionDBHandler.handler.AddEntryToFile(ex.ToString());
                Message.Invalid(PrintStatements.someThingWentWrong);

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
