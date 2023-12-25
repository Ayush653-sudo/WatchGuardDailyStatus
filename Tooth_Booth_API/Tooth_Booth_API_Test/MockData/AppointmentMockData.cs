using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Enum;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API_Test.MockData
{

    public static class AppointmentMockData
    {
        public static List<AppointmentAddDTO> listOfAppointmentDTO = new List<AppointmentAddDTO>()
       {
           new AppointmentAddDTO()
           {
               DoctorId="drayush",
               Prescription="take precaution",
               PaymentType=PaymentType.Cash
         
           }
       };
    
       
    }
}
