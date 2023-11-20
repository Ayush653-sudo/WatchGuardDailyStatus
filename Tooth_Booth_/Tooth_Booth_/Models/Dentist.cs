
using Tooth_Booth_.common.Enums;


namespace Tooth_Booth_.models
{


    public class Dentist
    {
       public string userName;
       public string clinicName;
       public DentistCategory category;
       public bool availability;
       public int maxAppointment;

        public Dentist()
        {

        }
        public Dentist(string userName, string clinicName, DentistCategory category,int maxAppointment)
            
        {
            this.userName = userName;
            this.clinicName = clinicName;
            this.category = category;
            this.availability = false;
            this.maxAppointment = maxAppointment;

        }

       

    }
}
