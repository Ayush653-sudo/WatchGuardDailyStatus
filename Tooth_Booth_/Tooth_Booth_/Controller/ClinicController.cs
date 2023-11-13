
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.Controller
{



    class ClinicController : IClinicController
    {


        public List<String> GetListOFClinicByCityName(string cityName)
        {
            List<String> list = new List<String>();
            list = ClinicDBHandler.handler.listOfClinic.FindAll((obj) => obj.clinicCity == cityName && obj.isverified == true).Select((obj) => obj.clinicName).ToList();
            return list;

        }
        public List<Clinic> GeListOfAllClinic()
        {
            return ClinicDBHandler.handler.listOfClinic;
        }


        public Clinic GetClinicByClinicName(string clinicName)
        {
            return ClinicDBHandler.handler.listOfClinic.Find((obj) => obj.clinicName == clinicName)!;

        }

        public bool UpdateClinic(Clinic updatedClinic)
        {

            int index = ClinicDBHandler.handler.listOfClinic.FindIndex((obj) => obj.clinicName == updatedClinic.clinicName);

           ClinicDBHandler.handler.listOfClinic[index] = updatedClinic;

            if (ClinicDBHandler.handler.UpdateEntryAtDB<Clinic>(ClinicDBHandler.handler.clinicPath, ClinicDBHandler.handler.listOfClinic))
                return true;
            else
                return false;

        }

        public bool DeleteClinic(Clinic clinic)
        {
            int index = ClinicDBHandler.handler.listOfClinic.FindIndex((obj) => obj.clinicName == clinic.clinicName);
            if (index == -1)
            {
                Message.Invalid("No Clinic Found With Given UserName");
                return false;
            }
            index = UserDBHandler.handler.listOfUser.FindIndex((obj) => obj.userName == clinic.listOFClinicAdmin[0]);
            UserDBHandler.handler.listOfUser.Remove(UserDBHandler.handler.listOfUser[index]);
            ClinicDBHandler.handler.listOfClinic.Remove(clinic);
            DentistDBHandler.handler.listOfDentist.RemoveAll(dentist => dentist.clinicName == clinic.clinicName);
            
            if (!ClinicDBHandler.handler.UpdateEntryAtDB<Clinic>(ClinicDBHandler.handler.clinicPath, ClinicDBHandler.handler.listOfClinic))
                return false;
            if (!DentistDBHandler.handler.UpdateEntryAtDB<Dentist>(DentistDBHandler.handler.dentistPath, DentistDBHandler.handler.listOfDentist))
                return false;
            if(!UserDBHandler.handler.UpdateEntryAtDB<User>(UserDBHandler.handler.userPath,UserDBHandler.handler.listOfUser))
                return false;
            return true;

        }
    }
}
