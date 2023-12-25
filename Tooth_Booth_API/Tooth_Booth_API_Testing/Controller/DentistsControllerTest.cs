using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
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
    public class DentistsControllerTest
    {
        Mock<IDentistBusiness> dentistsBusiness;

        [TestInitialize]
        public void Initialize()
        {
            dentistsBusiness = new Mock<IDentistBusiness>();
        }

        [TestMethod]
        public void Get_ValidClinicId_ReturnListOfDentisDTO()
        {
            var userClaims = new Claim[] { new Claim(ClaimTypes.Name, "testUser"), new Claim(ClaimTypes.NameIdentifier, "aaayyu"), new Claim(ClaimsIdentity.DefaultRoleClaimType, "Dentist") };
            var user = new ClaimsPrincipal(new ClaimsIdentity(userClaims));

            dentistsBusiness.Setup(x=>x.GetDentistByClinicId(It.IsAny<int>())).Returns(MockDentists.listOfDentists);
            var controller = new DentistController(dentistsBusiness.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext { User = user }

            };
            var result = controller.Get(1) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);


        }
        [TestMethod]
        public async Task Delete_ValidDentistId_ReturnSucess()
        {
           
            var userClaims = new Claim[] { new Claim(ClaimTypes.Name, "testUser"), new Claim(ClaimTypes.NameIdentifier, "aaayyu"), new Claim(ClaimsIdentity.DefaultRoleClaimType, "Dentist") };
            var user = new ClaimsPrincipal(new ClaimsIdentity(userClaims));
            dentistsBusiness.Setup(x=>x.DeleteDentist(It.IsAny<string>(),It.IsAny<string>())).ReturnsAsync(true);
            var controller = new DentistController(dentistsBusiness.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext { User = user }

            };
            var result =await controller.Delete("rr") ;
            var r = result as OkResult;
            Assert.IsNotNull(r);
            Assert.AreEqual(StatusCodes.Status200OK, r.StatusCode);


        }



    }
}
