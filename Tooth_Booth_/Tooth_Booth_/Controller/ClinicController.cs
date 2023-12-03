
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.Controller.Interfaces;
using Tooth_Booth_.database;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.Controller
{


   public class ClinicController : IClinicControllerForSuperAdmin, IClinicControllerForPatient
    {

        IDBHandler<Dentist> dentistDBHandler;
        IDBHandler<Clinic> clinicDBHandler;
        IDBHandler<User> userDBHandler;
        public ClinicController(IDBHandler<Dentist> dentistDBHandler, IDBHandler<Clinic> clinicDBHandler, IDBHandler<User> userDBHandler)
        {
            this.dentistDBHandler = dentistDBHandler;
            this.clinicDBHandler = clinicDBHandler;
            this.userDBHandler = userDBHandler;
        }

        public List<String> GetListOFClinicByCityName(string cityName)
        {
            List<String> list = new List<String>();
            List<Clinic> listOfClinic = clinicDBHandler.GetList();
            list = listOfClinic.FindAll((obj) => obj.clinicCity == cityName && obj.isverified == true).Select((obj) => obj.clinicName).ToList();
            return list;

        }
        public List<Clinic> GeListOfAllClinic()
        {
            return clinicDBHandler.GetList();
        }


        public Clinic GetClinicByClinicName(string clinicName)
        {
            List<Clinic> listOfClinic = clinicDBHandler.GetList();
            return listOfClinic.Find((obj) => obj.clinicName == clinicName)!;

        }

        public bool UpdateClinic(Clinic updatedClinic)
        {

            if (clinicDBHandler.Update(updatedClinic))
                return true;
            else
                return false;

        }

        public bool DeleteClinic(Clinic clinic)
        {

            List<Clinic> listOfClinic = clinicDBHandler.GetList();
            int index =listOfClinic.FindIndex((obj) => obj.clinicName == clinic.clinicName);
            if (index == -1)
            {
                Message.Invalid("No Clinic Found With Given UserName");
                return false;
            }
            List<User>listOfUser=userDBHandler.GetList();
            List<Dentist> listOfDentist = dentistDBHandler.GetList();
            var listOfDentistToRemoved=listOfDentist.FindAll((dentist)=>dentist.clinicName==clinic.clinicName);
               // from dentist in listOfDentist where dentist.clinicName==clinic.clinicName select dentist;
            if (!clinicDBHandler.Delete(clinic))
                return false;
            foreach (var obj in listOfDentistToRemoved)
            {
                var user = listOfUser.Find((use) => use.userName == obj.userName);
                if (!userDBHandler.Delete(user!))
                    return false;
                if (!dentistDBHandler.Delete(obj))
                    return false;
            }
            return true;

        }
    }
}
