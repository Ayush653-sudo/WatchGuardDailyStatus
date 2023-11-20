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

        IDBHandler<Dentist> dentistDBHandler;
        IDBHandler<User> userDBHandler;
        IDBHandler<Appointment> appointmentDBHandler;
       public DentistController(IDBHandler<Dentist>dentistDBHandler,IDBHandler<User>userDBHandler,IDBHandler<Appointment>appointmentDBHandler) {
            this.dentistDBHandler = dentistDBHandler;
            this.userDBHandler = userDBHandler;
            this.appointmentDBHandler = appointmentDBHandler;

        }
        
        public bool UpdateDentistAtDB(Dentist dentist)
        {
            return dentistDBHandler.Update(dentist);
            
        }
        public Dentist GetDentist(string userName)
        {
            List<Dentist> listOfDentist = dentistDBHandler.GetList();
            return listOfDentist.Find((obj) => obj.userName == userName)!;
        }

        public bool isPresentEarlier(string userName)
        {

            List<User> listOfUser = userDBHandler.GetList();
            if (listOfUser.FindIndex((obj) => obj.userName == userName) != -1)
                return true;
            return false;

        }
        public Dictionary<String, String> GetDentistList(string clinicName)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<Dentist> listOfDentist = dentistDBHandler.GetList();
            foreach (var obj in listOfDentist)
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

            List<Dentist> listOfDentist = dentistDBHandler.GetList();
            List<Dentist> listOfDentistAtClinic = new List<Dentist>();
            listOfDentistAtClinic=listOfDentist.FindAll((obj)=>obj.clinicName.Equals(clinicUserName));
            return listOfDentistAtClinic;

        }

        public bool RegisterNewDentistAtClinic(User user, Dentist dentist)
        {

            if (isPresentEarlier(dentist.userName))
            {
                return false;
            }
            if (userDBHandler.Add(user))
            {

                if (dentistDBHandler.Add(dentist))
                    return true;
                else
                {
                    userDBHandler.Delete(user);
                    return false;
                }
            }
            return false;


        }

        public bool DeleteDentistAtClinic(string clinicUserName, string userName)
        {

            List<Dentist> listOfDentist = dentistDBHandler.GetList();
            List<User>listOfUser=userDBHandler.GetList();
            Dentist dentistToBeDeleted = listOfDentist.Find((obj) => userName == obj.userName && clinicUserName == obj.clinicName)!;
            int userIndex = listOfUser.FindIndex((obj) => obj.userName == userName);
            if (dentistToBeDeleted == null)
            {
                Message.Invalid("No dentist found");
                return false;
            }

            List<Appointment> listOfAppointment = appointmentDBHandler.GetList();
            int appointmentIndexForDentist =listOfAppointment.FindIndex((obj) => obj.doctorUserName == userName && obj.appointmentDate == DateTime.Today);
            if (appointmentIndexForDentist != -1)
            {

                Message.Invalid("You cant delete him he has appointment with patients: ");
                return false;
            }

            if (dentistDBHandler.Delete(dentistToBeDeleted))
            {
                if (userDBHandler.Delete(listOfUser[userIndex]))
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
