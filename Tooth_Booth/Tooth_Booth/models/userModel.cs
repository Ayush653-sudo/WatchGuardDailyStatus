using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooth_Booth.models
{
     
    enum UserType
    {
        SuperAdmin=1,
        clinicAdmin,
        Dentist,
        Patient
    };


     class User
    {
        public string userName;
        public string password;
        public string emailAddress;
        public string phoneNumber;
        public UserType userType;
    }
}
