
using System;
using Tooth_Booth_.common;
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.Controller.Interfaces;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.models;
using Tooth_Booth_.View.Interfaces;

namespace Tooth_Booth_.View
{
    internal class PatientDashboard : IPatientDashboard
    {
        private IAppointmentControllerForPatient appointmentController;

        private IClinicControllerForPatient clinicController;

        private IDentistControllerForPatient dentistController;
        public PatientDashboard(IAppointmentControllerForPatient appointmentController,IClinicControllerForPatient clinicController, IDentistControllerForPatient dentistController)
        {
            this.appointmentController = appointmentController;
            this.clinicController = clinicController;
            this.dentistController = dentistController;
        }
        public void PatientDashboardView(User patient)
        {


            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(PrintStatements.welcome + PrintStatements.whiteSpace + patient.userName);
                Console.WriteLine(PrintStatements.patienMenu);

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
                            Console.WriteLine(PrintStatements.choiceCorrectlyPrint);
                            break;

                    }
                }
                catch
                {
                    Message.Invalid(PrintStatements.giveCorrectInput);
                }

            }
        }

        private string SelectDentistForAppointment(Dictionary<string,string>dentistAvailableInClinic)
        {
           
            Console.WriteLine(PrintStatements.followingDentist);

            foreach (var obj in dentistAvailableInClinic)
            {

                Console.WriteLine(PrintStatements.dentistName + obj.Key + PrintStatements.dentistspecialization + obj.Value);
            }
           
            return InputTaker.UserNameInput(PrintStatements.dentistNameForAppointment);

        }
        private PaymentType SelectPaymentType()
        {
            Console.WriteLine(PrintStatements.choosePaymentMethod);
            Console.WriteLine(PrintStatements.forUpi);
            Console.WriteLine(PrintStatements.forCash);
            PaymentType paymentType;
            try
            {
                var SelectType = (PaymentType)Convert.ToInt32(Console.ReadLine());
                switch (SelectType)
                {
                    case PaymentType.UPI: paymentType = PaymentType.UPI; break;
                    case PaymentType.Cash: paymentType = PaymentType.Cash; break;
                    default:
                        Console.WriteLine(PrintStatements.choiceCorrectlyPrint);
                        return paymentType=SelectPaymentType();

                }
            }
            catch (Exception ex)
            {
                ExceptionDBHandler.handler.AddEntryToFile(ex.ToString());
                Message.Invalid(PrintStatements.giveCorrectInput);
                return paymentType = SelectPaymentType();
            }
            return paymentType;
        }
        private int SelectClinic(List<string> clinicNames)
        {
            int index = -1, i = 0;
            while (true)
            {
                Console.WriteLine(PrintStatements.listOfClinicPrint);
                foreach (var name in clinicNames)
                {
                    i++;
                    Console.WriteLine(i + ") " + name);
                }

                Console.WriteLine(PrintStatements.choiceEnter);
                if (!int.TryParse(Console.ReadLine(), out index))
                {
                    Message.Invalid(PrintStatements.giveCorrectInput);

                }
                else
                    break;
            }
            return index;
        }

       private void PatientBookAppointmentView(User patient)
        {
         var cityName = InputTaker.ClinicCityInput(PrintStatements.enterCityName);
            
          List<String> clinicNames = clinicController.GetListOFClinicByCityName(cityName);
            if (clinicNames.Count <= 0)
            {
               
                Message.Invalid(PrintStatements.novAilableClinicPrint);
                return;
            }


            int index = SelectClinic(clinicNames);
            if (index <= 0 || index > clinicNames.Count)
            {
                Console.WriteLine(PrintStatements.giveCorrectInput);
                SelectClinic(clinicNames);

            }
            else
            {
                var nameOfClinic = clinicNames[index - 1];
                Dictionary<string, string> dentistAvailableInClinic = dentistController.GetDentistList(nameOfClinic);

                if (dentistAvailableInClinic.Count <= 0)
                {
                    Message.Invalid(PrintStatements.noDentistAvaliable);
                    return;
                }
                string selectedDentistName = SelectDentistForAppointment(dentistAvailableInClinic);
               
                if (!dentistAvailableInClinic.ContainsKey(selectedDentistName))
                {
                    Console.WriteLine(PrintStatements.giveCorrectInput);
                    SelectDentistForAppointment(dentistAvailableInClinic);               
                }
                else
                {
                    PaymentType paymentType = SelectPaymentType();
                    Appointment patientNewAppointment = new(patient.userName, selectedDentistName, nameOfClinic, "", paymentType);


                    if (appointmentController.BookNewAppointment(patientNewAppointment))
                        Console.WriteLine(PrintStatements.appointmentAdded);

                }


            }


        }

        private void ViewAllAppointment(User patient)
        {
            List<Appointment> appointments = appointmentController.GetAllAppointmentByUsername(patient.userName);

            if (appointments.Count <= 0)
            {
                Console.WriteLine(PrintStatements.noAppointmentFound);
                return;
            }
            Console.WriteLine(PrintStatements.listOfAppointment);

            foreach (Appointment appointment in appointments)
            {

                Console.WriteLine(PrintStatements.dashedLine);
                Console.WriteLine(PrintStatements.appointId + appointment.appointmentId);
                Console.WriteLine(PrintStatements.doctorUsrName + appointment.doctorUserName);
                Console.WriteLine(PrintStatements.clinicName + appointment.clinicName);
                Console.WriteLine(PrintStatements.prescription + appointment.prescription);
                Console.WriteLine(PrintStatements.appointmentDate + appointment.appointmentDate);

            }

        }

        private void CancelAppointmentByIdView(User patient)
        {
            int appointmentId=InputTaker.AppointmentIdInput(PrintStatements.cancleAppointmentId);            
            bool flag = appointmentController.cancleAppointById(patient.userName, appointmentId);
            if (flag)
                Console.WriteLine(PrintStatements.appointmentEntryDeleted);
            else
                Console.WriteLine(PrintStatements.somethingWentWrong);

        }

        private void LogOut(User patient)
        {
            patient = null;
            Program.StartApp();
        }

    }
}
