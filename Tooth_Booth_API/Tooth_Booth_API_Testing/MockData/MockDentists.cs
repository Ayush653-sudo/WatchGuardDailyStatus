using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.DTO.Auth;
using Tooth_Booth_API.Enum;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API_Testing.MockData
{
    public static class MockDentists
    {
        public static List<DentistDTO> listOfDentists = new List<DentistDTO>()
        {
            new DentistDTO()
            {
               Availability=true,
               Id="ayush",
               ClinicID=1,
               MaxAppointment=20,
               Category=DentistCategory.GeneralDentist

            }
         };
        public static List<Dentist> listOfDentist = new List<Dentist>()
        {
            new Dentist()
            {
               Id="ayush",
              Availability=true,
              ClinicID=1,
              MaxAppointment=20,
             Category=DentistCategory.GeneralDentist

            }
         };
        public static List<DentistRegistrationDTO> listOfDentistDTO = new List<DentistRegistrationDTO>()
        {
            new DentistRegistrationDTO()
         {
         UserName="ayush",
         Password ="Ayush@12",
         EmailAddress ="ayushsinght70@gmail.com",
         PhoneNumber="9636653732",
         Category =DentistCategory.Pedodontist,
         Availability=true, 
         MaxAppointment=10
        }
        };
     }
}