
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
            appointmentDate = DateTime.Parse("2023-11-23T00:00:00+05:30"),
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
          maxAppointment= 3,

        },
         new Dentist()
        {
          userName="drarpit",
          clinicName= "RoomShoom",
          category= DentistCategory.Orthodontist,
          availability= true,
          maxAppointment= 3
        }

          };
        static public List<User> listOfUser = new List<User>()
        {
             new User()
             {
              userName="ayush",
              password= "Ayush@22",
              emailAddress= "ayush@gmail.com",
              phoneNumber= "9636653732",
              userType=(UserType) 3
            },
              new User()
             {
              userName="drarpit",
              password= "Ayush@22",
              emailAddress= "ayush@gmail.com",
              phoneNumber= "9636653732",
              userType=UserType.Dentist
            },
              new User()
             {
              userName="Ayush",
              password= "Ayush@22",
              emailAddress= "ayush@gmail.com",
              phoneNumber= "9636653732",
              userType=UserType.clinicAdmin
            }

        };
        static public List<Clinic> listOfClinic = new List<Clinic>()
        { 
         new Clinic()
         {
           listOFClinicAdmin= new List<string>(){ "Ayush" },
           clinicName= "RoomShoom",
           description= "very nice clinic located nearby noida metro sector 142",
           clinicCity= "noida",
           isverified= true

         }
        };

    }
}
