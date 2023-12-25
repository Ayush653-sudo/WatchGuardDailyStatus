using System;
using System.Collections.Generic;
using System.Text;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.DTO.Auth;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API_Testing.MockData
{
    public static class MockClinics
    { 
        public static List<ClinicDTO>listOfClinics = new List<ClinicDTO>()
        {
            new ClinicDTO()
            {        
           ClinicId =1,
           ClinicAdminId="ayush", 
           ClinicName ="RoomShoom",
           Description="Very", 
           ClinicCity ="Noida",
           Isverified =false
        
            },
            new ClinicDTO()
            {
           ClinicId =2,
           ClinicAdminId="arpit",
           ClinicName ="RoomShoom",
           Description="Very nice clinic",
           ClinicCity ="Noida",
           Isverified =true

            }

        };
        public static List<Clinic> listOfClinic = new List<Clinic>()
        {
            new Clinic()
            {
           ClinicId =1,
           ClinicAdminId="ayush",
           ClinicName ="RoomShoom",
           Description="Very nice clinic",
           ClinicCity ="Noida",
           Isverified =false

            },
            new Clinic()
            {
           ClinicId =2,
           ClinicAdminId="ayush",
           ClinicName ="RoomShoom",
           Description="Very nice clinic",
           ClinicCity ="Noida",
           Isverified =true

            }

        };

        public static List<ClinicRegistrationDTO> listOfClinicRegistrationDTO = new List<ClinicRegistrationDTO>()
        {

         new ClinicRegistrationDTO()
         {
         UserName="ayush",
         Password ="Ayush@12",
         EmailAddress ="ayushsinght70@gmail.com",
         PhoneNumber="9636653732",
         ClinicName="Room",
         ClinicCity="Noida",
         Description="A new clinic "


         }
        
        };


    }
}
