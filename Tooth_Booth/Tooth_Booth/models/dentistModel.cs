
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooth_Booth.models
{

    enum DentistCategory
   {
    GeneralDentist,
    Pedodontist,
    Orthodontist,
    Periodontis,
    Endodontist,
    OralPathologists,
    Prosthodontist
   }
    class Dentist:User
    {
        string clinicName;
        DentistCategory category;
        DateTime availability;
       List<Appointment> appointment;
    }
}
