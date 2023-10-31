using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.common;

namespace Tooth_Booth_.models
{
  
   class Appointment
    {
       
        public int appointmentId;
        public string patientsUserName;
        public string doctorUserName;
        public DateTime appointmentDate;
        public string clinicName;
        public string prescription;
        public PaymentType paymentType;


        public Appointment() { }
        public Appointment(string patientsUserName,string doctorName,string clinicName,string prescription,PaymentType paymentType)
        {

            this.appointmentId = new Random().Next(4444);
            this.patientsUserName = patientsUserName;
            this.doctorUserName = doctorName;
            this.appointmentDate = DateTime.Today;
            this.clinicName = clinicName;   
            this.prescription = prescription;   
            this.paymentType = paymentType; 

        }
       
    }
}
