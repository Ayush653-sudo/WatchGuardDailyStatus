using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooth_Booth.models
{
    enum PaymentType
    {
        online,
        offline
    }
   class Appointment
    {
        public int aapointmentId;
        public string patientsUserName;
        public string doctorUserName;
        public DateTime appointmentDate;
        public string clinicName;
        public string prescription;
        public PaymentType paymentType;
    }
}
