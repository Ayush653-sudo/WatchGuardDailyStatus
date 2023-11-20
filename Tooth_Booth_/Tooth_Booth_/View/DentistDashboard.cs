using Tooth_Booth_.common;
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.Controller.Interfaces;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.models;
using Tooth_Booth_.View.Interfaces;

namespace Tooth_Booth_.View
{
    internal class DentistDashboard : IDentistDashboard
    {
        private IDentistControllerForDentist dentistController;
        private IAppointmentControllerForDentist appointmentController;
        public DentistDashboard(IDentistControllerForDentist dentistController,IAppointmentControllerForDentist appointmentController)
        {
            this.dentistController = dentistController;
            this.appointmentController = appointmentController;
        }
        public void DentistDashboardView(User dentistUser)
        {

            Dentist dentist = dentistController.GetDentist(dentistUser.userName);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(PrintStatements.dentistMenu);

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
                            Console.WriteLine(PrintStatements.logOutSucessfull);
                            return;
                          

                        default:
                            Console.WriteLine(PrintStatements.choiceCorrectlyPrint);
                            break;

                    }


                }
                catch (Exception ex) 
                {
                    ExceptionDBHandler.handler.AddEntryToFile(ex.ToString());
                    Message.Invalid(PrintStatements.giveCorrectInput);
                }

            }
        }

        void MarkAttendance(Dentist dentist)
        {
           
            bool isPresent = InputTaker.MarkAttendance(PrintStatements.dentistAvailable + DateTime.Today.ToString("yy/MM/dd") +
                                   PrintStatements.press2);
        
            Dentist newDentist = dentist;
            newDentist.availability = isPresent;

            if (dentistController.UpdateDentistAtDB(newDentist))
            {
                Console.WriteLine(PrintStatements.attendanceMarked);
            }
            else
            {
                Message.Invalid(PrintStatements.somethingWentWrong);

            }
        }

        void ViewAppointAsDates(Dentist dentist)
        {
            DateTime dateTime=InputTaker.DeteTimeInput(PrintStatements.dateOfAppointment);
                List<Appointment> listOfAppointmentByDates = new List<Appointment>();
                listOfAppointmentByDates = appointmentController.GetAppointmentByDates(dentist.userName, dateTime);
                if (listOfAppointmentByDates.Count <= 0)
                    Console.WriteLine(PrintStatements.noAppointmentFound);

                else
                {
                    foreach (Appointment appointment in listOfAppointmentByDates)
                    {

                        Console.WriteLine(PrintStatements.dashedLine);
                        Console.WriteLine(PrintStatements.appointId + appointment.appointmentId);
                        Console.WriteLine(PrintStatements.patientUserName + appointment.patientsUserName);
                        Console.WriteLine(PrintStatements.clinicName + appointment.clinicName);
                        Console.WriteLine(PrintStatements.prescription + appointment.prescription);
                        Console.WriteLine(PrintStatements.appointmentDate + appointment.appointmentDate.ToString("yy/MM/dd"));

                    }
                }           
        }

        void SelectAppointmentById(Dentist dentist)
        {

            int appointId=InputTaker.AppointmentIdInput(PrintStatements.enterAppoitmentID);
            Appointment appointment = appointmentController.GetAppointmentById(dentist.userName, appointId);

            if (appointment == null)
            {
                Console.WriteLine(PrintStatements.noAppointmentFound);

                return;
            }
            Console.WriteLine(PrintStatements.dashedLine);
            Console.WriteLine(PrintStatements.appointId + appointment.appointmentId);
            Console.WriteLine(PrintStatements.patientUserName + appointment.patientsUserName);
            Console.WriteLine(PrintStatements.clinicName + appointment.clinicName);
            Console.WriteLine(PrintStatements.prescription + appointment.prescription);
            Console.WriteLine(PrintStatements.appointmentDate + appointment.appointmentDate);
            Console.WriteLine(PrintStatements.dashedLine);

         Console.WriteLine(PrintStatements.wantToAddMorePrescription);
            var pressKey = Console.ReadLine();
            if (pressKey != "1")
            {
                return;
            }
            else
            {
                var prescription = InputTaker.AddPrescription(PrintStatements.addIt);
                appointment.prescription = prescription;
                appointmentController.AddPrescriptionToAppointment(appointment);
                
            }

        }

        void SelectMaxAppointment(Dentist dentist)
        {

            int maxAppointment=InputTaker.MaximumAppointmentInput(PrintStatements.maximumNumberOfAppointment);                
                dentist.maxAppointment = maxAppointment;
                if (dentistController.UpdateDentistAtDB(dentist))
                    Console.WriteLine(PrintStatements.updateSucessFully);
                else
                    Console.WriteLine(PrintStatements.someThingWentWrong);

        }
       
    }
}
