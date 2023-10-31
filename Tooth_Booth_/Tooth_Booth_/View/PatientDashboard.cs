using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.common;
using Tooth_Booth_.Controller;
using Tooth_Booth_.models;

namespace Tooth_Booth_.View
{
    internal class PatientDashboard
    {
        IPatientController patientController;

        public PatientDashboard(IPatientController patientController)
        {
            this.patientController = patientController;
        }
        public  void PatientDashboardView(Patient patient)
        {


            while(true)
            { 
             
             Console.WriteLine("Welcome" + "  " + patient.userName);
             Common.PatientStartView();

                try
                {
                    var pressedKey = (PatientDashboardE)Convert.ToInt32(Console.ReadLine());
                    switch (pressedKey)
                    {
                        case PatientDashboardE.BookAppointment:
                            PatientBookAppointmentView(patient);

                            break;

                        case PatientDashboardE.ViewPreviousAppointments:
                            ViewAllAppointment(patient);


                            break;

                        case PatientDashboardE.Logout:
                            LogOut(patient);
                            break;

                        case PatientDashboardE.CancleAppointment:
                            CancelAppointmentByIdView(patient);
                            break;

                        default:
                            Console.WriteLine("Please Choose correct option and Try Again");
                            break;

                    }
                }
                catch
                { 
                    Message.Invalid("Give Correct Input");
                }

               }
        }


        public void PatientBookAppointmentView(Patient patient)
        {
         clinicname:   Console.WriteLine("Enter City Name Where You Want To Search Dentist");
            var cityName=Console.ReadLine().Trim().ToLower();
            if(String.IsNullOrEmpty(cityName) )
            {
                Message.Invalid("Kindly Give Correct Input");
                goto clinicname;
            }
            

            List<String>clinicNames=patientController.GetListOFClinic(cityName);
            if(clinicNames.Count <=0 )
            {

                Message.Invalid("No Clinic Found In This City ");
                return;
            }

            int index=-1,i=0;
            Console.WriteLine("Following are the list of available clinics ");
            foreach(var name in clinicNames)
            {
                i++;
                Console.WriteLine(i + ") " + name);
            }
            
          clinicInput:  Console.WriteLine("Enter Your Choice:-> ");
           if(!int.TryParse(Console.ReadLine(),out index))
            {
                Message.Invalid("Try Again and Enter input correctly");
                goto clinicInput;
            }    

            if (index <= 0 || index > clinicNames.Count)
            {
                Console.WriteLine("Enter Correctly And Try Again!!");
                goto clinicInput;

            }
            else
            {
                var nameOfClinic = clinicNames[index-1];
                Dictionary<string, string> dentistAvailableInClinic = patientController.GetDentistList(nameOfClinic);

                if(dentistAvailableInClinic.Count<=0)
                {
                    Message.Invalid("No Dentist are Available in this clinic");
                    return;
                }
                Console.WriteLine("Following Dentist Are Available In These Clinic ");
               
                foreach(var obj in dentistAvailableInClinic)
                {
                    
                    Console.WriteLine("Dentist Name:  -->" + obj.Key + " Specialist In:  -->" + obj.Value);
                }

             DentistName:   Console.WriteLine("Write Name of That Dentist With Whome You Want To Book Your Appointment");
                string selectedDentistName=Console.ReadLine()!.Trim();
                if(String.IsNullOrEmpty(selectedDentistName))
                {
                    Console.WriteLine("Dentist Name Could Not Be Null");
                    goto DentistName;
                }
                if (dentistAvailableInClinic.ContainsKey(selectedDentistName))
                {
                    paymentmethod: Console.WriteLine("Choose Your Payment Method");
                    Console.WriteLine("Press 1 If You Will Pay From UPI");
                    Console.WriteLine("Press 2 If You Want To Pay In Cash");
                    PaymentType paymentType;
                    try
                    {
                      var  SelectType = (PaymentType)Convert.ToInt32(Console.ReadLine());
                        switch(SelectType)
                        {
                            case PaymentType.UPI:paymentType=PaymentType.UPI; break;
                            case PaymentType.Cash:paymentType=PaymentType.Cash; break;
                            default:Console.WriteLine("Choose correct option");
                                goto paymentmethod;

                        }
                    }
                    catch(Exception ex)
                    {
                        Message.Invalid("Enter Correct Input");
                        goto paymentmethod;
                    }

                    Appointment patientNewAppointment= new(patient.userName,selectedDentistName,nameOfClinic,"",paymentType);

                
                    if (patientController.BookNewAppointment(patientNewAppointment))
                        Console.WriteLine("Appointment Added Sucessfully!!!");
                }
                  else
                  {
                    Console.WriteLine("Choose Dentist Name Correctly");
                    goto DentistName;
                  }


            }


        }

        public void ViewAllAppointment(Patient patient)
        {
            List<Appointment> appointments = patientController.GetPersonAllAppointment(patient);

            if(appointments.Count <=0) {
                Console.WriteLine("No Appointment Found!!!");
                return;
            }
            Console.WriteLine("Following are the list of your appointments");

            foreach (Appointment appointment in appointments)
            {

                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("| Appointment Id:  -> " + appointment.appointmentId+"     " );
                Console.WriteLine("| DoctorUserName:  ->" + appointment.doctorUserName+"     ");
                Console.WriteLine("| ClinicName:      ->" + appointment.clinicName +"        ");
                Console.WriteLine("| Prescription:    ->" + appointment.prescription +"      ");
                Console.WriteLine("| Appointment Date:->" + appointment.appointmentDate+"    ");

            }

        }

        public void CancelAppointmentByIdView(Patient patient)
        {
           identer: Console.WriteLine("Enter Appoint Id To Cancle Make sure You could only cancle upcoming appoint");
            int appointmentId;
            if( !int.TryParse(Console.ReadLine(),out appointmentId))
            {
                Message.Invalid("Please Enter Id in Numeric Term Only");
                goto identer;
            }
            bool flag = patientController.cancleAppointById(patient,appointmentId);
            if (flag)
                Console.WriteLine("Appointment Entry Deleted SucessFully!!!");
            else
                Console.WriteLine("Something Went Wrong Please Try Again or No Appointment With Such Id  For the current data!!");
            
        }

        public void LogOut(Patient patient)
        {
            patient = null;
            Program.StartApp();
        }

    }
}
