using Moq;
using Tooth_Booth_.Controller.Interfaces;
using Tooth_Booth_.Controller;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.test.DummyData.test;
using Tooth_Booth_.Controller.ControllerInterfaces;

namespace AppTesting.Controller
{
    [TestClass]
    public class ClinicControllerTest
    {
        Mock<IDBHandler<Dentist>> dentistDBHandler = new Mock<IDBHandler<Dentist>>();
        Mock<IDBHandler<Clinic>> clinicDBHandler = new Mock<IDBHandler<Clinic>>();
        Mock<IDBHandler<User>> userDBHandler = new Mock<IDBHandler<User>>();

        [TestMethod]
       public void GetListOFClinicByCityName_ValidCityName_ListOfCityName()
        {
            string cityName = "noida";
            List<String>expectedListOfClinic=new List<String>() {"RoomShoom"};
            clinicDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfClinic);
            IClinicControllerForPatient clinicControllerForPatient = new ClinicController(dentistDBHandler.Object,clinicDBHandler.Object,userDBHandler.Object);
            var actualListOfClinicName=clinicControllerForPatient.GetListOFClinicByCityName(cityName);
            Assert.IsNotNull(actualListOfClinicName);
            Assert.AreEqual(expectedListOfClinic.Count, actualListOfClinicName.Count);

        }
        [TestMethod]
        public void GetListOFClinicByCityName_ValidCityName_EmptyListOfCityName()
        {
            string cityName = "noi";
            List<String> expectedListOfClinic = new List<String>();
            clinicDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfClinic);
            IClinicControllerForPatient clinicControllerForPatient = new ClinicController(dentistDBHandler.Object, clinicDBHandler.Object, userDBHandler.Object);
            var actualListOfClinicName = clinicControllerForPatient.GetListOFClinicByCityName(cityName);
            Assert.IsNotNull(actualListOfClinicName);
            Assert.AreEqual(expectedListOfClinic.Count, actualListOfClinicName.Count);

        }
        [TestMethod]
        public void GetListOfAllClinic_GetClinicList_AllClinicList()
        {
            clinicDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfClinic);
            IClinicControllerForSuperAdmin clinicControllerForSuperAdmin = new ClinicController(dentistDBHandler.Object, clinicDBHandler.Object, userDBHandler.Object);
            var actualListOfClinic=clinicControllerForSuperAdmin.GeListOfAllClinic();
            Assert.IsNotNull(actualListOfClinic);
            Assert.AreEqual(DummyData.listOfClinic.Count, actualListOfClinic.Count);
        }
        [TestMethod]
        public void GetClinicByClinicName_ValidClinicName_Clinic()
        {
            string clinicName = "RoomShoom";
            Clinic expectedClinic = DummyData.listOfClinic[0]; 
            clinicDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfClinic);
            IClinicControllerForSuperAdmin clinicControllerForSuperAdmin = new ClinicController(dentistDBHandler.Object, clinicDBHandler.Object, userDBHandler.Object);
            var actualClinic = clinicControllerForSuperAdmin.GetClinicByClinicName(clinicName);
            Assert.IsNotNull(actualClinic);
            Assert.AreEqual(expectedClinic.clinicName, actualClinic.clinicName);
            Assert.AreEqual(expectedClinic.clinicCity, actualClinic.clinicCity);
            Assert.AreEqual(expectedClinic.isverified, actualClinic.isverified);
            Assert.AreEqual(expectedClinic.description, actualClinic.description);

        }
        [TestMethod]
        public void UpdateClinic_ValidClinicObject_True()
        {
            DummyData.listOfClinic[0].clinicName = "RawatHospital";
            clinicDBHandler.Setup(x => x.Update(It.IsAny<Clinic>())).Returns(true);
            IClinicControllerForSuperAdmin clinicControllerForSuperAdmin = new ClinicController(dentistDBHandler.Object, clinicDBHandler.Object, userDBHandler.Object);
           bool actualOutput= clinicControllerForSuperAdmin.UpdateClinic(DummyData.listOfClinic[0]);
            Assert.IsTrue(actualOutput);
        }
        [TestMethod]
        public void DeleteClinic_ValidClinicObject_True()
        {
            dentistDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfDentist);
            userDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfUser);
            clinicDBHandler.Setup(x=>x.GetList()).Returns(DummyData.listOfClinic);
            dentistDBHandler.Setup(x => x.Delete(It.IsAny<Dentist>())).Returns(true);
            userDBHandler.Setup(x => x.Delete(It.IsAny<User>())).Returns(true);
            clinicDBHandler.Setup(x => x.Delete(It.IsAny<Clinic>())).Returns(true);
            IClinicControllerForSuperAdmin clinicControllerForSuperAdmin=new ClinicController(dentistDBHandler.Object, clinicDBHandler.Object, userDBHandler.Object);
            bool actualOutput = clinicControllerForSuperAdmin.DeleteClinic(DummyData.listOfClinic[0]);
            Assert.IsTrue(actualOutput);

        }


    }
}
