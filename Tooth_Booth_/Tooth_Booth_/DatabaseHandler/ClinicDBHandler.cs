
using Tooth_Booth_.common;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.DatabaseHandler
{
   sealed public class ClinicDBHandler:DBHandler,IDBHandler<Clinic>
    {


         List<Clinic> listOfClinic;

        string clinicPath = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Clinic.json";
        static IDBHandler<Clinic> _handler = null;
   
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
        public static IDBHandler<Clinic> handler
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
        public List<Clinic> GetList()
        {
            return listOfClinic;
        }
        public bool Update(Clinic newClinic)
        {
            int index = listOfClinic.FindIndex((obj) => obj.clinicName.Equals(newClinic.clinicName));
            listOfClinic[index] = newClinic;
            return UpdateEntryAtDB<Clinic>(clinicPath, listOfClinic);
        }
        public bool Delete(Clinic clinic)
        {
            int index = listOfClinic.FindIndex((obj) => obj.clinicName.Equals(clinic.clinicName));
            listOfClinic.RemoveAt(index);
            return UpdateEntryAtDB<Clinic>(clinicPath, listOfClinic);
        }

        public bool Add(Clinic clinic)
        {
            listOfClinic.Add(clinic);
            return UpdateEntryAtDB<Clinic>(clinicPath, listOfClinic);
        }

    }
}
