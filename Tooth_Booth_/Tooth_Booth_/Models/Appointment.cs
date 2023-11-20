
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.DatabaseHandler;

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

            int id = new Random().Next(4444);
           
            while (AppointmentDBHandler.handler.GetList().FindIndex((obj) => obj.appointmentId == id) != -1)
                id = new Random().Next(4444);

            this.appointmentId = id;
            this.patientsUserName = patientsUserName;
            this.doctorUserName = doctorName;
            this.appointmentDate = DateTime.Today;
            this.clinicName = clinicName;   
            this.prescription = prescription;   
            this.paymentType = paymentType; 

        }

        public override bool Equals(object obj)
        {
            Appointment appointment = obj as Appointment;
            if (appointment == null) return false;

            return
                this.patientsUserName.Equals(appointment.patientsUserName) &&
                this.appointmentDate.Equals(appointment.appointmentDate) &&
                this.clinicName.Equals(appointment.clinicName) &&
                this.doctorUserName.Equals(appointment.doctorUserName) &&
                this.appointmentId.Equals(appointment.appointmentId) &&
                this.paymentType.Equals(appointment.paymentType) &&
                this.prescription.Equals(appointment.prescription);
        }
    }
}
