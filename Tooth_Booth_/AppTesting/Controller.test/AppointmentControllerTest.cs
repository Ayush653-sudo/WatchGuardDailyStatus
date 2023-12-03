
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.Controller;
using Tooth_Booth_.models;
using Tooth_Booth_.Controller.Interfaces;
using Moq;
using Tooth_Booth_.test.DummyData.test;
using Tooth_Booth_.database;
namespace AppTesting.Controller
{
    [TestClass]
    public class AppointmentControllerTest
    {


        Mock<IDBHandler<Dentist>> dentistDBHandler = new Mock<IDBHandler<Dentist>>();
        Mock<IDBHandler<Appointment>> appointmentDBHandler = new Mock<IDBHandler<Appointment>>();



        [TestMethod]
        public void GetAppointmentById_ValidUserNameAndid_Appointment()
        {
            string doctorUserName = "drayush";
            int appointmentId = 456;
            appointmentDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfAppointment);
            IAppointmentControllerForDentist appointmentControllerForDentist = new AppointmentController(dentistDBHandler.Object, appointmentDBHandler.Object);
           Appointment expectedAppointment = DummyData.listOfAppointment[0];
           Appointment actualAppointment= appointmentControllerForDentist.GetAppointmentById(doctorUserName, appointmentId);
           Assert.AreEqual(expectedAppointment, actualAppointment);

        }
        [TestMethod]
        public void AddPrescriptionToAppointment_AddValidPrescription_True()
        {
            
            Appointment appointment = new Appointment();
            appointment.appointmentId = 456;
            appointment.patientsUserName = "lalu53";
            appointment.doctorUserName = "drayush";
            appointment.appointmentDate = DateTime.Parse("2023-11-16T00:00:00+05:30");
            appointment.clinicName = "AJHOSPITAL";
            appointment.prescription = "Take Precution Carefully";
            appointment.paymentType = PaymentType.Cash;
            bool expected = true;
            appointmentDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfAppointment);
            appointmentDBHandler.Setup(x => x.Update(It.IsAny<Appointment>())).Returns(true);
            IAppointmentControllerForDentist _appointmentControllerForDentist = new AppointmentController(dentistDBHandler.Object, appointmentDBHandler.Object);
            bool actual = _appointmentControllerForDentist.AddPrescriptionToAppointment(appointment);
            Assert.AreEqual(expected,actual);

        }
        [TestMethod]
        public void BookNewAppointment_AddAppointment_True()
        {
            Appointment appointment = new Appointment();
            appointment.appointmentId = 447;
            appointment.patientsUserName = "lalu53";
            appointment.doctorUserName = "drayush";
            appointment.appointmentDate = DateTime.Parse("2023-11-20");
            appointment.clinicName = "AJHOSPITAL";
            appointment.prescription = "Take Precution Carefully";
            appointment.paymentType = PaymentType.Cash;
            bool expected = true;
            dentistDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfDentist);
            appointmentDBHandler.Setup(x=>x.Add(It.IsAny<Appointment>())).Returns(true);
            dentistDBHandler.Setup(x => x.Update(It.IsAny<Dentist>())).Returns(true);
            IAppointmentControllerForPatient _appointmentControllerForPatient = new AppointmentController(dentistDBHandler.Object, appointmentDBHandler.Object);
            bool actual=_appointmentControllerForPatient.BookNewAppointment(appointment);
            Assert.AreEqual(expected,actual);

        }
        [TestMethod]
        public void CancleAppointById_ValidUserNameAndId_True()
        {
            string userName = "lalu53";
            int id = 663;           
            bool expected = true;
            appointmentDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfAppointment);
            dentistDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfDentist);
            appointmentDBHandler.Setup(x => x.Delete(It.IsAny<Appointment>())).Returns(true);
            dentistDBHandler.Setup(x => x.Update(It.IsAny<Dentist>())).Returns(true);
            IAppointmentControllerForPatient _appointmentControllerForPatient = new AppointmentController(dentistDBHandler.Object, appointmentDBHandler.Object);          
            bool actual=_appointmentControllerForPatient.CancleAppointById(userName, id);
            Assert.AreEqual(expected,actual);

        }


    }
}