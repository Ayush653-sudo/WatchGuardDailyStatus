using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;
using Tooth_Booth_.common;
using Tooth_Booth_.database;
using Tooth_Booth_.View;
using Tooth_Booth_.Controller;

namespace Tooth_Booth_.models
{
   
  class Clinic  :User  
    {
       public string clinicName;  
       public string description;
       public string clinicCity;
       public bool isverified;
       public Clinic() : 
              base()
        {

        }
       public Clinic(User user,string clinicName,string description, string clinicCity) 
          :base(user)
        { 
         
         this.clinicName = clinicName;
         this.description = description;
         this.clinicCity= clinicCity;
         this.isverified = false;
         

        }





    }
}
