using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tooth_Booth_API_Test.MockData;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.Controllers;
using Microsoft.AspNetCore.Http;

namespace Tooth_Booth_API_Test.Controller
{
    [TestClass]
    class AppointmentControllerTest
    {
        Mock<IAppointmentBusiness> appointmentBusiness=new Mock<IAppointmentBusiness>();

        [TestMethod]
        public void Post_AddAppointmentDTO_ReturnSuccess()
         {
            var claim = new Claim("test", "IdOfYourChoosing");
            var mockIdentity =
                Mock.Of<ClaimsIdentity>(ci => ci.FindFirst(It.IsAny<string>()) == claim);
            AppointmentController app = new AppointmentController(appointmentBusiness.Object);
            app.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = (ClaimsPrincipal)Mock.Of<IPrincipal>(ip => ip.Identity == mockIdentity)
                }
            };

            var result=app.Post(AppointmentMockData.listOfAppointmentDTO[0]) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);




            // var context = new Mock<ControllerBase>();
            //var mockIdentity = new Mock<IIdentity>();
            //AppointmentController app = new AppointmentController(appointmentBusiness.Object);
            //var userClaims = new Claim[] { new Claim(ClaimTypes.NameIdentifier=)};
            //var user = new ClaimsPrincipal(new ClaimsIdentity(userClaims));

            //app.ControllerContext = new ControllerContext()
            //{
            //    HttpContext = new DefaultHttpContext()
            //    {
            //        User=new ClaimsPrincipal(new ClaimsIdentity(

            //            ))
            //    }
            //}

            //mockIdentity.Setup(x => x.Name).Returns("test_name");
            //mockIdentity.Setup(x => x.GetUserId()).Returns("aaa");
            //app.Post(AppointmentMockData.listOfAppointmentDTO[0])




        }


    }
}
