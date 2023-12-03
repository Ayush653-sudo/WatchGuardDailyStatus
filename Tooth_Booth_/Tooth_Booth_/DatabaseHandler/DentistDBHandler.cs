
using System.Xml.Linq;
using Tooth_Booth_.common;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.DatabaseHandler
{
    public class DentistDBHandler : DBHandler, IDBHandler<Dentist>
    {
        List<Dentist> listOfDentist;
        string dentistPath = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Dentist.json";
        static IDBHandler<Dentist> _handler;



        private DentistDBHandler()
        {

            listOfDentist = new List<Dentist>();
            try
            {
                string dentistFileContent = File.ReadAllText(dentistPath);

                if (!string.IsNullOrEmpty(dentistFileContent))
                    listOfDentist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dentist>>(dentistFileContent)!;

            }
            catch (Exception ex)
            {


                ExceptionDBHandler.handler.AddEntryToFile(ex.Message.ToString());
                Message.Invalid(PrintStatements.someThingWentWrong);

            }

        }
        public static IDBHandler<Dentist> handler
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

        public List<Dentist> GetList()
        {
            return listOfDentist;
        }
        public bool Update(Dentist newDentist)
        {
            int index = listOfDentist.FindIndex((obj) => obj.userName.Equals(newDentist.userName));
            listOfDentist[index] = newDentist;
            return UpdateEntryAtDB<Dentist>(dentistPath, listOfDentist);
        }
        public bool Delete(Dentist dentist)
        {
            int index = listOfDentist.FindIndex((obj) => obj.userName==dentist.userName);
            listOfDentist.RemoveAt(index);
            return UpdateEntryAtDB<Dentist>(dentistPath, listOfDentist);
        }

        public bool Add(Dentist dentist)
        {
            listOfDentist.Add(dentist);
            return UpdateEntryAtDB<Dentist>(dentistPath, listOfDentist);
        }



    }
}
