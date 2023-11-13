
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
        public IAppointmentControllerForPatient appointmentController {  get; set; }

        public IClinicController clinicController { get; set; }  

        public IDentistController dentistController { get; set; }
        public PatientDashboard(IAppointmentControllerForPatient appointmentController,IClinicController clinicController, IDentistController dentistController)
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


        public void PatientBookAppointmentView(User patient)
        {
        clinicname: Console.WriteLine(PrintStatements.enterCityName);
            var cityName = Console.ReadLine()!.Trim().ToLower();
            if (CheckValidity.NullCheck(cityName))
            {
                Message.Invalid(PrintStatements.fieldCantNull);
                goto clinicname;
            }


            List<String> clinicNames = clinicController.GetListOFClinicByCityName(cityName);
            if (clinicNames.Count <= 0)
            {
                //"No Clinic Found In This City"
                Message.Invalid(PrintStatements.novAilableClinicPrint);
                return;
            }

            int index = -1, i = 0;
            Console.WriteLine(PrintStatements.listOfClinicPrint);
            foreach (var name in clinicNames)
            {
                i++;
                Console.WriteLine(i + ") " + name);
            }

        clinicInput: Console.WriteLine(PrintStatements.choiceEnter);
            if (!int.TryParse(Console.ReadLine(), out index))
            {
                Message.Invalid(PrintStatements.giveCorrectInput);
                goto clinicInput;
            }

            if (index <= 0 || index > clinicNames.Count)
            {
                Console.WriteLine(PrintStatements.giveCorrectInput);
                goto clinicInput;

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
                Console.WriteLine(PrintStatements.followingDentist);

                foreach (var obj in dentistAvailableInClinic)
                {

                    Console.WriteLine(PrintStatements.dentistName + obj.Key + PrintStatements.dentistspecialization + obj.Value);
                }

            DentistName: Console.WriteLine(PrintStatements.appointmentDentistName);
                string selectedDentistName = Console.ReadLine()!.Trim();
                if (CheckValidity.NullCheck(selectedDentistName))
                {
                    Console.WriteLine(PrintStatements.fieldCantNull);
                    goto DentistName;
                }
                if (dentistAvailableInClinic.ContainsKey(selectedDentistName))
                {
                paymentmethod: Console.WriteLine(PrintStatements.choosePaymentMethod);
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
                                goto paymentmethod;

                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionDBHandler.handler.AddEntryAtDB<String>(ExceptionDBHandler.handler.ExceptionPath, ex.ToString(), ExceptionDBHandler.handler.ListOfException);
                        Message.Invalid(PrintStatements.giveCorrectInput);
                        goto paymentmethod;
                    }

                    Appointment patientNewAppointment = new(patient.userName, selectedDentistName, nameOfClinic, "", paymentType);


                    if (appointmentController.BookNewAppointment(patientNewAppointment))
                        Console.WriteLine(PrintStatements.appointmentAdded);
                }
                else
                {
                    Console.WriteLine(PrintStatements.giveCorrectInput);
                    goto DentistName;
                }


            }


        }

        public void ViewAllAppointment(User patient)
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

        public void CancelAppointmentByIdView(User patient)
        {
        identer: Console.WriteLine(PrintStatements.cancleAppointmentId);
            int appointmentId;
            if (!int.TryParse(Console.ReadLine(), out appointmentId))
            {
                Message.Invalid(PrintStatements.giveCorrectInput);
                goto identer;
            }
            bool flag = appointmentController.cancleAppointById(patient.userName, appointmentId);
            if (flag)
                Console.WriteLine(PrintStatements.appointmentEntryDeleted);
            else
                Console.WriteLine(PrintStatements.somethingWentWrong);

        }

        public void LogOut(User patient)
        {
            patient = null;
            Program.StartApp();
        }

    }
}
