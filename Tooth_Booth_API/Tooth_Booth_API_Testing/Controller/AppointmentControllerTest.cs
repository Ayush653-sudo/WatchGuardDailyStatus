using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Claims;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.Controllers;
using Microsoft.AspNetCore.Http;
using Tooth_Booth_API_Testing.MockData;
using Tooth_Booth_API.DTO;
using System;
using Microsoft.AspNetCore.JsonPatch;
using Tooth_Booth_API.Models;
using System.Threading.Tasks;

namespace Tooth_Booth_API_Test.Controller
{
    [TestClass]
  public  class AppointmentControllerTest
    {
       
        
        Mock<IAppointmentBusiness> appointmentBusiness;
        [TestInitialize]
        public void Initialize()
        {
           appointmentBusiness = new Mock<IAppointmentBusiness>();
        }

        [TestMethod]
        public void Post_AddAppointmentDTO_ReturnSuccess()
        {

            var userClaims = new Claim[] { new Claim(ClaimTypes.Name, "testUser"),new Claim(ClaimTypes.NameIdentifier,"aaayyu") };
            var user = new ClaimsPrincipal(new ClaimsIdentity(userClaims));
            appointmentBusiness.Setup(x => x.AddAppointment(It.IsAny<AppointmentAddDTO>(), It.IsAny<string>())).Returns(true);
            var controller = new AppointmentController(appointmentBusiness.Object);
           // controller.ModelState.AddModelError("DentistId","Enter DentistId")
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext { User = user }

            };
            var result=controller.Post(MockAppointments.listOfAddDTOAppointment[0]) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

        }
        [TestMethod]
        public void Get_EnterValidDateAndClinicId_ReturnListOfAppointmentDTO()
        {
            var userClaims = new Claim[] { new Claim(ClaimTypes.Name, "testUser"), new Claim(ClaimTypes.NameIdentifier, "aaayyu"),new Claim(ClaimsIdentity.DefaultRoleClaimType,"Dentist") };
            var user = new ClaimsPrincipal(new ClaimsIdentity(userClaims));
            appointmentBusiness.Setup(x => x.GetAppointmentFilter(It.IsAny<DateTime>(),It.IsAny<int?>(),It.IsAny<string>(),It.IsAny<string>(),It.IsAny<int>())).Returns(MockAppointments.listOfDTOAppointment);
            var controller = new AppointmentController(appointmentBusiness.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext { User = user }

            };
            var result = controller.Get(DateTime.Today,null,null,null,2) as OkObjectResult;
            Assert.IsNotNull(result);

        }
        //[TestMethod]
        //public void Patch_EnterValidPatchRequest_ReturnSucess()
        //{
        //    var userClaims = new Claim[] { new Claim(ClaimTypes.Name, "testUser"), new Claim(ClaimTypes.NameIdentifier, "aaayyu"), new Claim(ClaimsIdentity.DefaultRoleClaimType, "Dentist") };
        //    var user = new ClaimsPrincipal(new ClaimsIdentity(userClaims));
        //    appointmentBusiness.Setup(x => x.UpdateAppointment(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<JsonPatchDocument<Appointment>>()));
        //    var controller = new AppointmentController(appointmentBusiness.Object);
        //    controller.ControllerContext = new ControllerContext()
        //    {
        //        HttpContext = new DefaultHttpContext { User = user }

        //    };
        //    var result = controller.Patch(1, );

        //}

        [TestMethod]
       
        public async Task Delete_ValidId_ReturnSucess()
        {
            var userClaims = new Claim[] { new Claim(ClaimTypes.Name, "testUser"), new Claim(ClaimTypes.NameIdentifier, "aaayyu"), new Claim(ClaimsIdentity.DefaultRoleClaimType, "Dentist") };
            var user = new ClaimsPrincipal(new ClaimsIdentity(userClaims));
            appointmentBusiness.Setup(x => x.DeleteAppointById(It.IsAny<int>(), It.IsAny<string>())).Returns(true);
            var controller = new AppointmentController(appointmentBusiness.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext { User = user }

            };
            var result =  await controller.Delete(2);
           var r=result as OkResult;
            Assert.IsNotNull(r);            
            Assert.AreEqual(StatusCodes.Status200OK,r.StatusCode);

        }

      


       


    }
}

