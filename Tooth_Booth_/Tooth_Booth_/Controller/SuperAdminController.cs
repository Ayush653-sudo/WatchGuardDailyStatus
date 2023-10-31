using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.Controller
{
   
    interface ISuperAdminController
    {
        List<Clinic> GeListOfClinic();

        Clinic GetClinic(string userName);

        bool UpdateClinic(Clinic updatedClinic);

        bool DeleteClinic(string userName);

        bool AddNewAdmin(User user);
    }
   internal class SuperAdminController:ISuperAdminController
    {


        public List<Clinic> GeListOfClinic()
        {
            return DBController.handler.listOfClinic;
        }


        public Clinic GetClinic(string userName)
        {
            return DBController.handler.listOfClinic.Find((obj) => obj.userName == userName)!;


        }

        public bool UpdateClinic(Clinic updatedClinic)
        {

            int index = DBController.handler.listOfClinic.FindIndex((obj) => obj.userName == updatedClinic.userName);

            DBController.handler.listOfClinic[index] = updatedClinic;

            if (DBController.handler.UpdateEntryAtDB<Clinic>(DBController.handler.clinicPath, DBController.handler.listOfClinic))
                return true;
            else
                return false;

        }

        public bool DeleteClinic(string userName)
        {
            int index = DBController.handler.listOfClinic.FindIndex((obj) => obj.userName == userName);
            if (index == -1)
            {
                Message.Invalid("No Clinic Found With Given UserName");
                return false;
            }
            DBController.handler.listOfClinic.RemoveAt(index);
            DBController.handler.listOfDentist.RemoveAll(dentist => dentist.clinicName == userName);
            if (!DBController.handler.UpdateEntryAtDB<Clinic>(DBController.handler.clinicPath, DBController.handler.listOfClinic))
                return false;
            if (!DBController.handler.UpdateEntryAtDB<Dentist>(DBController.handler.dentistPath, DBController.handler.listOfDentist))
                return false;
            return true;

        }

        public bool AddNewAdmin(User user)
        {

            SuperAdmin superadmin = new SuperAdmin(user);
            return DBController.handler.AddEntryAtDB(superadmin);
        }


    }
}
