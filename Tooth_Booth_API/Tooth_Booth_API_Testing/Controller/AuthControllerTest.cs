using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tooth_Booth_API.BusinessLogic.Interface;
using Microsoft.AspNetCore.Identity;
using Tooth_Booth_API.Controllers;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tooth_Booth_API_Testing.MockData;
using System.Threading.Tasks;
using Tooth_Booth_API.DTO.Auth;

namespace Tooth_Booth_API_Testing.Controller
{
    [TestClass]
    public class AuthControllerTest
    {

        Mock<IAuthBusiness> authBusiness;

        [TestInitialize] 
        public void Initialize()
        {
            authBusiness = new Mock<IAuthBusiness>();
        }


        [TestMethod]
        public async Task RegisterDentist_ValidDentist_ReturnSucess()
        {
            var userClaims = new Claim[] { new Claim(ClaimTypes.Name, "testUser"), new Claim(ClaimTypes.NameIdentifier, "aaayyu"), new Claim(ClaimsIdentity.DefaultRoleClaimType, "Dentist") };
            var user = new ClaimsPrincipal(new ClaimsIdentity(userClaims));
            authBusiness.Setup(x => x.AddDentist( It.IsAny<string>(), It.IsAny<DentistRegistrationDTO>())).ReturnsAsync(true);
            AuthController controller=new AuthController(authBusiness.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext { User = user }

            };
            var result = await controller.RegisterDentist(MockDentists.listOfDentistDTO[0]) as OkObjectResult;
            
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

        }
        [TestMethod]
        public async Task RegisterClinic_ValidClinicInput_ReturnSucess()
        {
            authBusiness.Setup(x => x.AddClinic(It.IsAny<ClinicRegistrationDTO>())).ReturnsAsync(true);
            AuthController controller = new AuthController(authBusiness.Object);
            var result = await controller.RegisterClinic(MockClinics.listOfClinicRegistrationDTO[0]);
              var r=result as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, r.StatusCode);
        }

        [TestMethod]
        public async Task RegisterPatient_ValidPatientInput_ReturnSucess()
        {
            authBusiness.Setup(x => x.AddUser(It.IsAny<IdentityUser>(),It.IsAny<string>(),It.IsAny<string>())).ReturnsAsync(true);
            AuthController controller = new AuthController(authBusiness.Object);
            var result = await controller.RegisterPatient(Registration.registrationDTO[0]);
            var r = result as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, r.StatusCode);
        }
        [TestMethod]
        public async Task RegisterAdmin_ValidPatientInput_ReturnSucess()
        {
            authBusiness.Setup(x => x.AddUser(It.IsAny<IdentityUser>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);
            AuthController controller = new AuthController(authBusiness.Object);
            var result = await controller.RegisterAdmin(Registration.registrationDTO[0]);
            var r = result as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, r.StatusCode);
        }
        [TestMethod]
        public async Task Login_ValidPatientInput_ReturnSucess()
        {
           
            authBusiness.Setup(x=>x.LogIn(It.IsAny<UserLoginDTO>())).ReturnsAsync(true);
            AuthController controller = new AuthController(authBusiness.Object);
            var result = await controller.Login(Registration.listOfUserLogin[0]);
            var r = result as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, r.StatusCode);

        }





    }
}
