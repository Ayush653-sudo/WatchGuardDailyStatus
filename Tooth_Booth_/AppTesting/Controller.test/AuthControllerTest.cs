

using Moq;
using Tooth_Booth_.common.Enums;
using Tooth_Booth_.Controller;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.database;
using Tooth_Booth_.test.DummyData.test;
using Tooth_Booth_.models;
using Tooth_Booth_.View.Interfaces;

namespace AppTesting.Controller
{
    [TestClass]
    public class AuthControllerTest
    {

        Mock<IDBHandler<User>> userDBHandler = new Mock<IDBHandler<User>>();
        Mock<IDBHandler<Clinic>> clinicDBHandler = new Mock<IDBHandler<Clinic>>();
        Mock<IAuthDashboard>authDashboard = new Mock<IAuthDashboard>();

        [TestMethod]
        public void GetUserFromDB_ValidUserName_ReturnUser()
        {
            Dictionary<string,string>logInCred= new Dictionary<string,string>();

             logInCred["username"] = "ayush";
            logInCred["password"] = "Ayush@22";
            User expectedUser = new User()
            {
                userName = "ayush",
                password = "Ayush@22",
                emailAddress = "ayush@gmail.com",
                phoneNumber = "9636653732",
                userType = (UserType)3
            };
            userDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfUser);
            AuthController authController=new AuthController(authDashboard.Object,userDBHandler.Object,clinicDBHandler.Object);
            User actualUser = authController.GetUserFromDB(logInCred);
            Assert.IsNotNull(actualUser);
            Assert.AreEqual(expectedUser.userName, actualUser.userName);
            Assert.AreEqual(expectedUser.phoneNumber, actualUser.phoneNumber);
            Assert.AreEqual(expectedUser.password, actualUser.password);
            Assert.AreEqual(expectedUser.userType, actualUser.userType);
            Assert.AreEqual(expectedUser.emailAddress, actualUser.emailAddress);

        }
        [TestMethod]
        public void GetUserFromDB_InValidUserName_ReturnNull()
        {
            Dictionary<string, string> logInCred = new Dictionary<string, string>();

            logInCred["username"] = "ayu";
            logInCred["password"] = "Ayush@22";
            User expectedUser = null;
            userDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfUser);
            AuthController authController = new AuthController(authDashboard.Object, userDBHandler.Object, clinicDBHandler.Object);
            User actualUser = authController.GetUserFromDB(logInCred);
            Assert.IsNull(actualUser);
           

        }
        [TestMethod]
        public void IsPresentEarlier_AlreadyPresentUserName_True()
        {
            string userName = "ayush";
            bool expected = true;
            userDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfUser);
            AuthController authController = new AuthController(authDashboard.Object, userDBHandler.Object, clinicDBHandler.Object);
            bool actual = authController.IsPresentEarlier(userName);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void IsPresentEarlier_NewUserName_false()
        {
            string userName = "aayu";
            bool expected = false;
            userDBHandler.Setup(x => x.GetList()).Returns(DummyData.listOfUser);
            AuthController authController = new AuthController(authDashboard.Object, userDBHandler.Object, clinicDBHandler.Object);
            bool actual = authController.IsPresentEarlier(userName);
            Assert.AreEqual(expected, actual);

        }



    }
}
