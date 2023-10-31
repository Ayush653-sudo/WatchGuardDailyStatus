
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.common;
using Tooth_Booth_.Controller;
using Tooth_Booth_.database;

namespace Tooth_Booth_.models
{


    class Dentist:User
    {

      
       public string clinicName;
       public DentistCategory category;
       public bool availability;
       public int maxAppointment;

        public Dentist():base()
        {

        }
        public Dentist(User user, string clinicName, DentistCategory category,int maxAppointment)
            :base(user)
        {
            this.clinicName = clinicName;
            this.category = category;
            this.availability = false;
            this.maxAppointment = maxAppointment;

        }

       

    }
}
