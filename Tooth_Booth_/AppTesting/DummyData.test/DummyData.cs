using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.models;

namespace Tooth_Booth_.test.DummyData.test
{
     static class DummyData
    {


        static public List<Appointment> listOfAppointment = new List<Appointment>()
            {
               new Appointment()
           {
            appointmentId = 456,
                    patientsUserName = "lalu53",
                    doctorUserName = "drayush",
                    appointmentDate = DateTime.Parse("2023-11-16T00:00:00+05:30"),
                    clinicName = "AJHOSPITAL",
                    prescription = "Take Precution Carefully",
                    paymentType = PaymentType.Cash,
                },
        new Appointment()
        {
                     appointmentId = 455,
                    patientsUserName = "lalu53",
                    doctorUserName = "drayush",
                    appointmentDate = DateTime.Parse("2023-11-16T00:00:00+05:30"),
                    clinicName = "AJHOSPITAL",
                    prescription = "Take Precution Carefully",
                    paymentType = PaymentType.Cash,
          },
        new Appointment()
        {
             appointmentId = 663,
             patientsUserName = "lalu53",
             doctorUserName = "drayush",
            appointmentDate = DateTime.Parse("2023-11-20T00:00:00+05:30"),
            clinicName = "AJHOSPITAL",
            prescription = "",
            paymentType = PaymentType.Cash,


        }
    };
        static public List<Dentist> listOfDentist = new List<Dentist>() { 
        new Dentist()
        {
       userName="drayush",
       clinicName= "AJHOSPITAL",
       category= DentistCategory.Orthodontist,
       availability= true,
       maxAppointment= 3
        }
        
          };

    }
}
