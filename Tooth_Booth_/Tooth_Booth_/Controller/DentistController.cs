using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.models;

namespace Tooth_Booth_.Controller
{
    interface IDentistController
    {
        bool UpdateDentistAtDB(Dentist dentist);
        List<Appointment> GetAppointmentByDates(Dentist dentist,DateTime dateTime);

        Appointment GetAppointmentById(Dentist dentist,int id);

        bool AddPrescriptionToPatient(Appointment appointment);

    }
    class DentistController:IDentistController
    {

        public bool UpdateDentistAtDB(Dentist dentist)
        {
            int i = DBController.handler.listOfDentist.FindIndex((obj)=>obj.userName==dentist.userName);

            
                
                    DBController.handler.listOfDentist[i] = dentist;
                    if(DBController.handler.UpdateEntryAtDB<Dentist>(DBController.handler.dentistPath, DBController.handler.listOfDentist))
                    return true;

               
            

            return false;
        }


        public List<Appointment> GetAppointmentByDates(Dentist dentist,DateTime dateTime)
        {

            return DBController.handler.listOfAppointment.FindAll((obj) => obj.appointmentDate == dateTime && dentist.userName == obj.doctorUserName);
        }
        public Appointment GetAppointmentById(Dentist dentist,int id)
        {

            return DBController.handler.listOfAppointment.Find((obj) => obj.appointmentId == id && dentist.userName == obj.doctorUserName)!;

        }

        public bool AddPrescriptionToPatient(Appointment appointment)
        {

            int index = DBController.handler.listOfAppointment.FindIndex((obj) => obj.appointmentId == appointment.appointmentId);
            DBController.handler.listOfAppointment[index] = appointment;

            if (DBController.handler.UpdateEntryAtDB<Appointment>(DBController.handler.appointmentPath, DBController.handler.listOfAppointment))
                return true;
            else
                return false;


        }

    }
}
