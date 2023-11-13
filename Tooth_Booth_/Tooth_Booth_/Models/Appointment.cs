
using Tooth_Booth_.common.Enums;

namespace Tooth_Booth_.models
{
  
   public class Appointment
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
