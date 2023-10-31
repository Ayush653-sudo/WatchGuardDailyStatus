using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.Controller
{

    interface IClinicController
    {
       List<Dentist> GetDentistAtClinic(Clinic clinic);
       bool RegisterNewDentist(Dentist updatedDentist);
       bool DeleteDentist(Clinic clinic, string userName);

    }

   class ClinicController:IClinicController
    {
      
        public List<Dentist> GetDentistAtClinic(Clinic clinic)
        {

            List<Dentist> listOfDentistAtClinic = new List<Dentist>();
            foreach (var obj in DBController.handler.listOfDentist)
            {
                if (obj.clinicName == clinic.userName)
                    listOfDentistAtClinic.Add(obj);
            }
            return listOfDentistAtClinic;

        }

        public bool RegisterNewDentist(Dentist dentist)
        {

            return DBController.handler.AddEntryAtDB(dentist);

        }

        public bool DeleteDentist(Clinic clinic,string userName)
        {

            int index = DBController.handler.listOfDentist.FindIndex((obj) => obj.userName == userName && clinic.userName == obj.clinicName);
            if (index == -1)
            {
                Message.Invalid("No dentist found");
                return false;
            }

            int k = DBController.handler.listOfAppointment.FindIndex((obj) => obj.doctorUserName == userName && obj.appointmentDate == DateTime.Today);
            if (k != -1)
            {

                Message.Invalid("You cant delete him he has appointment with patients: ");
                return false;
            }

            DBController.handler.listOfDentist.RemoveAt(index);

            if (DBController.handler.UpdateEntryAtDB<Dentist>(DBController.handler.dentistPath, DBController.handler.listOfDentist))
                return true;
            else
                return false;

        }
    }
}
