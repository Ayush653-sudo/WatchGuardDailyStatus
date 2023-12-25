using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.Controllers;
using Tooth_Booth_API_Testing.MockData;

namespace Tooth_Booth_API_Testing.Controller
{
    [TestClass]

    public class ClinicsControllerTest
    {
        Mock<IClinicsBusiness> clinicsBusiness;

        [TestInitialize]
        public void Initialize()
        {
           clinicsBusiness = new Mock<IClinicsBusiness>();
        }
        [TestMethod]
       public void Get_ClinicNameAndClinicCity_ReturnListOfClinicDTO()
        {
            var userClaims = new Claim[] { new Claim(ClaimTypes.Name, "testUser"), new Claim(ClaimTypes.NameIdentifier, "aaayyu"), new Claim(ClaimsIdentity.DefaultRoleClaimType, "Dentist") };
            var user = new ClaimsPrincipal(new ClaimsIdentity(userClaims));
           
            clinicsBusiness.Setup(x => x.GetAllClinic(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>())).Returns(MockClinics.listOfClinics);
            var controller = new ClinicsController(clinicsBusiness.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext { User = user }

            };
            var result = controller.Get(1,null,null,null) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK,result.StatusCode);


        }
        [TestMethod]
        public async Task Delete_ValidId_ReturnSucess()
        {
            var userClaims = new Claim[] { new Claim(ClaimTypes.Name, "testUser"), new Claim(ClaimTypes.NameIdentifier, "aaayyu"), new Claim(ClaimsIdentity.DefaultRoleClaimType, "Dentist") };
            var user = new ClaimsPrincipal(new ClaimsIdentity(userClaims));
            clinicsBusiness.Setup(x => x.DeleteClinic(It.IsAny<int>())).ReturnsAsync(true);
            var controller = new ClinicsController(clinicsBusiness.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext { User = user }

            };
            var result = await controller.Delete(1);
            var r = result as OkResult;
            Assert.IsNotNull(r);
            Assert.AreEqual(StatusCodes.Status200OK, r.StatusCode);

        }

    }

}
