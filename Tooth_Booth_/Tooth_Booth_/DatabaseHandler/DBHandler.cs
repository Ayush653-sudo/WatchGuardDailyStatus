using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.Controller;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.database
{

   interface IDBHandler
    {
       public List<Clinic> listOfClinic { get; set; }
       public List<Dentist> listOfDentist { get; set; }
       public List<Patient> listOfPatient { get; set; }
       public List<Appointment> listOfAppointment { get; set; }
       public List<SuperAdmin> listOfAdmin { get; set; }
       public string clinicPath {  get; set; }
       public string dentistPath {  get; set; }
       public string patientPath {  get; set; }
       public string appointmentPath {  get; set; }
       public string adminPath { get; set; }
        
       public bool AddEntryAtDB(Object obj);
       public bool UpdateEntryAtDB<T>(string path, List<T> list);
       public Object GetUserFromDB(Dictionary<string, string> logInCred);

    }
      class  DBHandler:IDBHandler
       {
        public static IDBHandler handler;
         public List<Clinic> listOfClinic { get; set; }
          public List<Dentist> listOfDentist { get; set; }
          public List<Patient> listOfPatient { get; set; }
          public List<Appointment> listOfAppointment { get; set; }
          public List<SuperAdmin> listOfAdmin { get; set; }

          public string clinicPath { set; get; }
       
          public string dentistPath {  set; get; }
          public string patientPath {  set; get; }
          public string appointmentPath {  set; get; }
          public string adminPath {  set; get; }
          

         public DBHandler()
        {
            listOfClinic = new List<Clinic>();

            listOfDentist = new List<Dentist>();

            listOfPatient = new List<Patient>();

            listOfAppointment = new List<Appointment>();

            listOfAdmin = new List<SuperAdmin>();

            clinicPath= @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Clinic.json";

            dentistPath = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Dentist.json";

            patientPath = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Patient.json";

            appointmentPath = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Appointment.json";

            adminPath = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Admin.json";
            try
            {

                string clinicFileContent = File.ReadAllText(clinicPath);

                string dentistFileContent = File.ReadAllText(dentistPath);

                string patientFileContent = File.ReadAllText(patientPath);

                string appointmentFileContent = File.ReadAllText(appointmentPath);

                string adminFileContent = File.ReadAllText(adminPath);
           
                listOfClinic = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Clinic>>(clinicFileContent)!;

                listOfDentist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dentist>>(dentistFileContent)!;

                listOfPatient = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Patient>>(patientFileContent)!;
            
                listOfAppointment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Appointment>>(appointmentFileContent)!;

                listOfAdmin = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SuperAdmin>>(adminFileContent)!;
            }
            catch (Exception ex)
            {
                Message.Invalid("SomeThing Went Wrong With Files");
            }

        }
    


        public Object GetUserFromDB(Dictionary<string, string> logInCred)
        {
            Object user;
            user=listOfDentist.Find((obj) => obj.userName == logInCred["username"] && obj.password == logInCred["password"])!;
            if (user != null)
            {
                return user;
            }
            user= listOfAdmin.Find((obj) => obj.userName == logInCred["username"] && obj.password == logInCred["password"])!;
            if (user != null)
            {
                return user;
            }
            user = listOfPatient.Find((obj) => obj.userName == logInCred["username"] && obj.password == logInCred["password"])!;
            if (user != null)
            {
                return user;
            }
            user = listOfClinic.Find((obj) => obj.userName == logInCred["username"] && obj.password == logInCred["password"])!;
            if (user != null)
            {
                return user;
            }
            return null;


        }

       
        bool isPresentEarlier(string userName)
        {
            if (listOfAdmin.FindIndex((obj) => obj.userName == userName) != -1)
                return true;
            else if (listOfClinic.FindIndex((obj) => obj.userName == userName) != -1)
                return true;
            else if (listOfPatient.FindIndex((obj) => obj.userName == userName) != -1)
                return true;
            else if(listOfDentist.FindIndex((obj) => obj.userName == userName) != -1)
                return true;
                 
            return false;

        }
        public bool AddEntryAtDB(Object obj)
        {
            if(obj is SuperAdmin)
            {
                
                SuperAdmin admin = (SuperAdmin)obj;
                if(isPresentEarlier(admin.userName))
                {
                    Message.Invalid("UserName is alreadey Exists in Entry");
                    return false;
                }
                listOfAdmin.Add(admin);

                if (UpdateEntryAtDB<SuperAdmin>(adminPath, listOfAdmin))
                    return true;

                else
                    return false;

            }
            else if (obj is Clinic)
            {
              Clinic clinic = (Clinic)obj;
                if (isPresentEarlier(clinic.userName))
                {
                    Message.Invalid("UserName is alreadey Exists in Entry");
                    return false;
                }
                listOfClinic.Add(clinic);
                if (UpdateEntryAtDB<Clinic>(clinicPath, listOfClinic))
                    return true;
                else
                    return false;

            }
            else if(obj is Patient)
            {
                Patient patient = (Patient)obj;
                if (isPresentEarlier(patient.userName))
                {
                    Message.Invalid("UserName is alreadey Exists in Entry");
                    return false;
                }
                listOfPatient.Add(patient);
                if (UpdateEntryAtDB<Patient>(patientPath, listOfPatient))
                    return true;
                else
                    return false;

            }
            else if (obj is Dentist)
            {
                Dentist dentist = (Dentist)obj;
                if (isPresentEarlier(dentist.userName))
                {
                    Message.Invalid("UserName is alreadey Exists in Entry");
                    return false;
                }
                listOfDentist.Add(dentist);
                if (UpdateEntryAtDB<Dentist>(dentistPath, listOfDentist))
                    return true;
                else
                    return false;

            }
            else if(obj is Appointment)
            {
                Appointment newAppointment = (Appointment)obj;
                listOfAppointment.Add(newAppointment);

                if (UpdateEntryAtDB<Appointment>(appointmentPath, listOfAppointment))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
      
        public bool UpdateEntryAtDB<T>(string path, List<T> list)
        {
            try
            {
                var jsonFormattedContent = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                File.WriteAllText(path, jsonFormattedContent);
            }
            catch
            {
                return false;
            }
            return true;
        }
       
        
    }
}
