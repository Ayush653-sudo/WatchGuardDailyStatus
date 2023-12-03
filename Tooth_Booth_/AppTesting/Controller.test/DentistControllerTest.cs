using Moq;
using Tooth_Booth_.Controller.Interfaces;
using Tooth_Booth_.Controller;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.test.DummyData.test;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.common.Enums;

namespace AppTesting.Controller
{
    [TestClass]
    public class DentistControllerTest
    {
        Mock<IDBHandler<User>> userDBHandler = new Mock<IDBHandler<User>>();
        Mock<IDBHandler<Dentist>> dentistDBHandler = new Mock<IDBHandler<Dentist>>();
        Mock<IDBHandler<Appointment>> appointmentDBHandler = new Mock<IDBHandler<Appointment>>();
        [TestMethod]
        public void UpdateDentistAtDB_ValidObject_ReturnTrue()
        {
           dentistDBHandler.Setup(x => x.Update(DummyData.listOfDentist[0])).Returns(true);
           IDentistControllerForDentist dentistController = new DentistController(dentistDBHandler.Object,userDBHandler.Object,appointmentDBHandler.Object);
            bool actualOutput = dentistController.UpdateDentistAtDB(DummyData.listOfDentist[0]);
            Assert.IsTrue(actualOutput);
        }
        [TestMethod]
        public void GetDentistByUserName_validUserName_Dentist()
        {
            string userName = "drarpit";
            dentistDBHandler.Setup(x=>x.GetList()).Returns(DummyData.listOfDentist);
            IDentistControllerForDentist dentistControllerForDentist= new DentistController(dentistDBHandler.Object, userDBHandler.Object, appointmentDBHandler.Object);
            Dentist actualDentist=dentistControllerForDentist.GetDentistByUserName(userName);
            Dentist expectedDentist = DummyData.listOfDentist.Find((obj) => obj.userName == userName)!;
            Assert.IsNotNull(actualDentist);
            Assert.AreEqual(expectedDentist.userName, actualDentist.userName);
            Assert.AreEqual(expectedDentist.clinicName, actualDentist.clinicName);
            Assert.AreEqual(expectedDentist.maxAppointment, actualDentist.maxAppointment);
            Assert.AreEqual(expectedDentist.availability, actualDentist.availability);

        }
        [TestMethod]
        public void GetDentistByUserName_InValidUserName_Null()
        {
            string userName = "drarp";
            dentistDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfDentist);
            IDentistControllerForDentist dentistControllerForDentist = new DentistController(dentistDBHandler.Object, userDBHandler.Object, appointmentDBHandler.Object);
            Dentist actualDentist = dentistControllerForDentist.GetDentistByUserName(userName);
            Dentist expectedDentist = DummyData.listOfDentist.Find((obj) => obj.userName == userName)!;
            Assert.IsNull(actualDentist);
            Assert.IsNull(actualDentist);

        }
        [TestMethod]
        public void RegisterNewDentistAtClinic_NewDentist_True()
        {
            dentistDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfDentist);
            User user = new User()
            {
                userName = "drmilind",
                password = "Ayush@22",
                emailAddress = "ayush@gmail.com",
                phoneNumber = "9636653732",
                userType = UserType.Dentist
            };
            Dentist dentist = new Dentist()
            {
                userName = "drmilind",
                clinicName = "RoomShoom",
                category = DentistCategory.Orthodontist,
                availability = false,
                maxAppointment = 0

            };
            dentistDBHandler.Setup(x => x.Add(It.IsAny<Dentist>())).Returns(true);
            userDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfUser);
            userDBHandler.Setup(x => x.Add(It.IsAny<User>())).Returns(true);
            userDBHandler.Setup(x => x.Delete(It.IsAny<User>())).Returns(true);
            IDentistControllerForClinicAdmin dentistControllerForClinicAdmin = new DentistController(dentistDBHandler.Object, userDBHandler.Object, appointmentDBHandler.Object);
            bool actualOutput=dentistControllerForClinicAdmin.RegisterNewDentistAtClinic(user,dentist);
            Assert.IsTrue(actualOutput);
        }
        [TestMethod]
        public void DeleteDentistAtClinic_ValidDentist_True()
        {
            userDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfUser);
            dentistDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfDentist);
            appointmentDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfAppointment);
            userDBHandler.Setup(x => x.Delete(It.IsAny<User>())).Returns(true);
            dentistDBHandler.Setup(x => x.Delete(It.IsAny<Dentist>())).Returns(true);
            IDentistControllerForDentist dentistControllerForDentist = new DentistController(dentistDBHandler.Object, userDBHandler.Object, appointmentDBHandler.Object);
            bool actualOutput=dentistControllerForDentist.DeleteDentistAtClinic("RoomShoom", "drarpit");
            Assert.IsTrue(actualOutput);
        }
        [TestMethod]
        public void DeleteDentistAtClinic_InValidDentist_True()
        {
            userDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfUser);
            dentistDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfDentist);
            appointmentDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfAppointment);
            userDBHandler.Setup(x => x.Delete(It.IsAny<User>())).Returns(true);
            dentistDBHandler.Setup(x => x.Delete(It.IsAny<Dentist>())).Returns(true);
            IDentistControllerForDentist dentistControllerForDentist = new DentistController(dentistDBHandler.Object, userDBHandler.Object, appointmentDBHandler.Object);
            bool actualOutput = dentistControllerForDentist.DeleteDentistAtClinic("RoomShoom", "drarp");
            Assert.IsFalse(actualOutput);
        }


    }
}
