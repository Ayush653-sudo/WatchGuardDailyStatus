using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.common;
using Tooth_Booth_.Controller;
using Tooth_Booth_.database;
using Tooth_Booth_.models;

namespace Tooth_Booth_.View
{
    internal class DentistDashboard
    {
        IDentistController dentistController;

        public DentistDashboard(IDentistController dentistController)
        {
            this.dentistController=dentistController;
        }
        public void DentistDashboardView(Dentist dentist)
        {
            while (true)
            {
                Common.DentistStartView();

                try
                {
                    var pressedKey = (DentistStarter)Convert.ToInt32(Console.ReadLine());
                    switch (pressedKey)
                    {
                        case DentistStarter.ViewAppointment:
                            ViewAppointAsDates(dentist);
                            break;

                        case DentistStarter.MarkAttendance:
                            MarkAttendance(dentist);
                            break;

                        case DentistStarter.SelectAppointment:
                            SelectAppointmentById(dentist);
                            break;

                        case DentistStarter.MaxAppointments:
                            SelectMaxAppointment(dentist);
                            break;
                        
                        case DentistStarter.LogOut:
                            LogOut(dentist);
                            break;

                        default:
                            Console.WriteLine("Enter Input Correctly");
                            break;

                    }
                    

                }
                catch
                {
                    Message.Invalid("Give Correct Input");
                }

            }
        }
         
         

        

         void MarkAttendance(Dentist dentist)
         {
            
          attendanceinput:  Console.WriteLine("Press 1 IF you are available at " + DateTime.Today.ToString("yy/MM/dd") +
                            "\nElse Press 2 ");
            Console.WriteLine("Enter Your Choice: ");


                Attendance pressedKey;
                try
                {
                    pressedKey = (Attendance)Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please Enter Numeric Value");
                    goto attendanceinput;
                }
                bool isPresent = false;

                switch (pressedKey)
                {
                    case Attendance.Present:
                        isPresent = true;
                        break;
                    case Attendance.Absent:
                        isPresent = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter Correct Option");
                        goto attendanceinput;
                       

                }
                Dentist newDentist = dentist;
                newDentist.availability = isPresent;

                if (dentistController.UpdateDentistAtDB(newDentist))
                {
                    Console.WriteLine("Your Attendance is Marked Sucessfully!!! ");
                }
                else
                {
                    Message.Invalid("Something Went Wrong");

                }
            }
            
          

        

        void ViewAppointAsDates(Dentist dentist)
        {
            Console.WriteLine("Enter Date Whose Appointments You Want To See(eg:2023-10-30): ");
            string dT=Console.ReadLine()!;
            DateTime dateTime;
            var isValidDate = DateTime.TryParse(dT, out dateTime);

            if (isValidDate)
            {
                List<Appointment> listOfAppointmentByDates = new List<Appointment>();
                listOfAppointmentByDates =dentistController.GetAppointmentByDates(dentist,dateTime);
                if (listOfAppointmentByDates.Count <=0)
                    Console.WriteLine("You Do Not Have Any Appointment On The Entered Dates");

                else
                {
                    foreach (Appointment appointment in listOfAppointmentByDates)
                    {

                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("| Appointment Id:  -> " + appointment.appointmentId);
                        Console.WriteLine("| PatientUserName: -> " + appointment.patientsUserName);
                        Console.WriteLine("| ClinicName:      -> " + appointment.clinicName);
                        Console.WriteLine("| Prescription:    -> " + appointment.prescription);
                        Console.WriteLine("| Appointment Date:-> " + appointment.appointmentDate.ToString("yy/MM/dd"));

                    }
                }
            }
            else
            {
                Console.WriteLine("Please Try Again And Enter a Valid Date: ");
            }
       
        }

         void SelectAppointmentById(Dentist dentist)
        {

            Console.WriteLine("Enter Appointment Id Of Patient");
            int appointId;
                if(!int.TryParse(Console.ReadLine(),out appointId))
            {
                Message.Invalid("Enter Id Correctly");
                return;

            }

            Appointment appointment = dentistController.GetAppointmentById(dentist,appointId);


            if (appointment == null)
            { Console.WriteLine("Sorry You Do Not Have Any appointment With Following Id");

                return;
            }
           


                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("| Appointment Id:  -> " + appointment.appointmentId+"     ");
                Console.WriteLine("| PatientUserName: ->" + appointment.patientsUserName + " ");
                Console.WriteLine("| ClinicName:      ->" + appointment.clinicName + "       ");
                Console.WriteLine("| Prescription:    ->" + appointment.prescription + "     ");
                Console.WriteLine("| Appointment Date:->" + appointment.appointmentDate + "  ");
                Console.WriteLine("-----------------------------------------------------------");

prescriptionselector: Console.WriteLine("Do You Want To Add Prescription:Then Press 1 OtherWise Any Other Key To Go At Dashboard");
                var pressKey = Console.ReadLine();
                if (pressKey == "1")
                {
                    Console.WriteLine("Add IT:->");
                    var prescription = Console.ReadLine()!.Trim();
                    if(Common.NullCheck(prescription))
                    {
                    Console.WriteLine("Field can't be empty!!");
                    goto prescriptionselector;
                    }
                    appointment.prescription = prescription;
                    dentistController.AddPrescriptionToPatient(appointment);
                }
                else
                {
                   
                    return;
                }

        }

         void SelectMaxAppointment(Dentist dentist)
         {
           maxAppointmentLabel: Console.WriteLine("How many Maximum number of Appointment you could hold for the day");
            int maxAppointment;
            if(!int.TryParse(Console.ReadLine(), out maxAppointment)||maxAppointment<0)
            {
                Console.WriteLine("Enter Number Correctly!!!");
                goto maxAppointmentLabel;
            }
            else
            {
                dentist.maxAppointment = maxAppointment;
                if(dentistController.UpdateDentistAtDB(dentist))
                    Console.WriteLine("Updation Sucessfull!!!");
                else
                    Console.WriteLine("Something went wrong!!");
            }

        }
         void LogOut(Dentist dentist)
         {
            dentist = null;
            Console.WriteLine("LogOut Sucessfully!!!");
            Program.StartApp();
         }







    }
}
