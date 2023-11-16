using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.Controller.Interfaces;
using Tooth_Booth_.database;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.Controller
{

    class DentistController : IDentistControllerForClinicAdmin, IDentistControllerForDentist, IDentistControllerForPatient
    {

        public bool UpdateDentistAtDB(Dentist dentist)
        {
            int i = DentistDBHandler.handler.listOfDentist.FindIndex((obj) => obj.userName == dentist.userName);
            DentistDBHandler.handler.listOfDentist[i] = dentist;
            if (DentistDBHandler.handler.UpdateEntryAtDB<Dentist>(DentistDBHandler.handler.dentistPath, DentistDBHandler.handler.listOfDentist))
                return true;
            return false;
        }
        public Dentist GetDentist(string userName)
        {
            return DentistDBHandler.handler.listOfDentist.Find((obj) => obj.userName == userName)!;
        }
        public Dictionary<String, String> GetDentistList(string clinicName)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var obj in DentistDBHandler.handler.listOfDentist)
            {
                if (obj.clinicName == clinicName && obj.availability == true && obj.maxAppointment > 0)
                {
                    dict[obj.userName] = obj.category.ToString();
                }
            }
            return dict;
        }

        public List<Dentist> GetDentistAtClinic(string clinicUserName)
        {

            List<Dentist> listOfDentistAtClinic = new List<Dentist>();
            foreach (var obj in DentistDBHandler.handler.listOfDentist)
            {
                if (obj.clinicName == clinicUserName)
                    listOfDentistAtClinic.Add(obj);
            }
            return listOfDentistAtClinic;

        }

        public bool RegisterNewDentistAtClinic(User user, Dentist dentist)
        {

            if (AuthController.isPresentEarlier(dentist.userName))
            {
                return false;
            }
            if (UserDBHandler.handler.AddEntryAtDB<User>(UserDBHandler.handler.userPath, user, UserDBHandler.handler.listOfUser))
            {

                if (DentistDBHandler.handler.AddEntryAtDB<Dentist>(DentistDBHandler.handler.dentistPath, dentist, DentistDBHandler.handler.listOfDentist))
                    return true;
                else
                {
                    UserDBHandler.handler.listOfUser.Remove(user);
                    UserDBHandler.handler.UpdateEntryAtDB<User>(UserDBHandler.handler.userPath, UserDBHandler.handler.listOfUser);
                    return false;
                }
            }
            return false;


        }

        public bool DeleteDentistAtClinic(string clinicUserName, string userName)
        {

            int index = DentistDBHandler.handler.listOfDentist.FindIndex((obj) => userName == obj.userName && clinicUserName == obj.clinicName);
            int userIndex = UserDBHandler.handler.listOfUser.FindIndex((obj) => obj.userName == userName);
            if (index == -1)
            {
                Message.Invalid("No dentist found");
                return false;
            }

            int appointmentIndexForDentist = AppointmentDBHandler.handler.listOfAppointment.FindIndex((obj) => obj.doctorUserName == userName && obj.appointmentDate == DateTime.Today);
            if (appointmentIndexForDentist != -1)
            {

                Message.Invalid("You cant delete him he has appointment with patients: ");
                return false;
            }

            DentistDBHandler.handler.listOfDentist.RemoveAt(index);
            UserDBHandler.handler.listOfUser.RemoveAt(userIndex);

            if (DentistDBHandler.handler.UpdateEntryAtDB<Dentist>(DentistDBHandler.handler.dentistPath, DentistDBHandler.handler.listOfDentist))
            {
                if (UserDBHandler.handler.UpdateEntryAtDB<User>(UserDBHandler.handler.userPath, UserDBHandler.handler.listOfUser))
                    return true;
                else
                {
                    return false;
                }

            }
            else
                return false;

        }


    }
}
