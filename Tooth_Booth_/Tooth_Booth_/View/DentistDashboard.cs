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
       public IDentistController dentistController {  get; set; }
       public IAppointmentControllerForDentist appointmentController { get; set; }
        public DentistDashboard(IDentistController dentistController,IAppointmentControllerForDentist appointmentController)
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
                            LogOut(dentist);
                            break;

                        default:
                            Console.WriteLine(PrintStatements.choiceCorrectlyPrint);
                            break;

                    }


                }
                catch (Exception ex) 
                {
                    ExceptionDBHandler.handler.AddEntryAtDB<String>(ExceptionDBHandler.handler.ExceptionPath, ex.ToString(), ExceptionDBHandler.handler.ListOfException);
                    Message.Invalid(PrintStatements.giveCorrectInput);
                }

            }
        }

        void MarkAttendance(Dentist dentist)
        {

        attendanceinput: Console.WriteLine(PrintStatements.dentistAvailable + DateTime.Today.ToString("yy/MM/dd") +
                                   PrintStatements.press2);
            Console.WriteLine(PrintStatements.choiceEnter);


            Attendance pressedKey;
            try
            {
                pressedKey = (Attendance)Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(PrintStatements.giveCorrectInput);
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
                    Console.WriteLine(PrintStatements.choiceCorrectlyPrint);
                    goto attendanceinput;


            }
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
            Console.WriteLine(PrintStatements.dateOfAppointment);
            string dT = Console.ReadLine()!;
            DateTime dateTime;
            var isValidDate = DateTime.TryParse(dT, out dateTime);

            if (isValidDate)
            {
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
            else
            {
                Console.WriteLine(PrintStatements.enterValidDate);
            }

        }

        void SelectAppointmentById(Dentist dentist)
        {

            Console.WriteLine(PrintStatements.enterAppoitmentID);
            int appointId;
            if (!int.TryParse(Console.ReadLine(), out appointId))
            {
                Message.Invalid(PrintStatements.giveCorrectInput);
                return;

            }

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

        prescriptionselector: Console.WriteLine(PrintStatements.wantToAddMorePrescription);
            var pressKey = Console.ReadLine();
            if (pressKey == "1")
            {
                Console.WriteLine(PrintStatements.addIt);
                var prescription = Console.ReadLine()!.Trim();
                if (CheckValidity.NullCheck(prescription))
                {
                    Console.WriteLine(PrintStatements.fieldCantNull);
                    goto prescriptionselector;
                }
                appointment.prescription = prescription;
                appointmentController.AddPrescriptionToAppointment(appointment);
            }
            else
            {

                return;
            }

        }

        void SelectMaxAppointment(Dentist dentist)
        {
        maxAppointmentLabel: Console.WriteLine(PrintStatements.maximumNumberOfAppointment);
            int maxAppointment;
            if (!int.TryParse(Console.ReadLine(), out maxAppointment) || maxAppointment < 0)
            {
                Console.WriteLine(PrintStatements.giveCorrectInput);
                goto maxAppointmentLabel;
            }
            else
            {
                dentist.maxAppointment = maxAppointment;
                if (dentistController.UpdateDentistAtDB(dentist))
                    Console.WriteLine(PrintStatements.updateSucessFully);
                else
                    Console.WriteLine(PrintStatements.someThingWentWrong);
            }

        }
        void LogOut(Dentist dentist)
        {
            dentist = null;
            Console.WriteLine(PrintStatements.logOutSucessfull);
            Program.StartApp();
        }
    }
}
