using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Enum;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API_Testing.MockData
{
    public static class MockAppointments
    {
        public static List<AppointmentAddDTO> listOfAddDTOAppointment = new List<AppointmentAddDTO>()
        {
            new AppointmentAddDTO()
            {
                DoctorId="ayush",
                Prescription="Take precaution",
                PaymentType=PaymentType.UPI
            },
            new AppointmentAddDTO()
            {
                Prescription="take medicine properly",
                PaymentType=PaymentType.UPI
            }
        };
        public static List<AppointmentDTO> listOfDTOAppointment = new List<AppointmentDTO>()
        {
            new AppointmentDTO()
             {
               AppointmentId =1,

               DoctorId ="ayush",

               AppointmentDate =DateTime.Today,

               ClinicId =2,

               Prescription="Take Precaution carefully", 

               PaymentType =PaymentType.UPI
             }

        };
        public static List<Appointment> listOfAppointment = new List<Appointment>()
        {
            new Appointment()
             {
               AppointmentId =1,

               DoctorId ="ayush",
               PatientUserName="ayush",

               AppointmentDate =DateTime.Today,

               ClinicId =2,

               Prescription="Take Precaution carefully",

               PaymentType =PaymentType.UPI
             },
             new Appointment()
             {
               AppointmentId =2,

               DoctorId ="ayush",
               PatientUserName="ayush",

               AppointmentDate =DateTime.Today,

               ClinicId =2,

               Prescription="",

               PaymentType =PaymentType.UPI
             }

        };
        static List<PatchHander> listOfPatchRequest = new List<PatchHander>()
        {
            new PatchHander()
            {
                op="replace",
                path="/Prescription",
                value="take meal correctly"
            }
        };
        

    }
}
