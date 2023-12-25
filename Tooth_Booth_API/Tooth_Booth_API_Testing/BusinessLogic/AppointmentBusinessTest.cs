using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Tooth_Booth_API.BusinessLogic;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.UOW.Interface;
using Tooth_Booth_API_Testing.MockData;

namespace Tooth_Booth_API_Testing.BusinessLogic
{

    [TestClass]
    public class AppointmentBusinessTest
    {
        Mock<IUnitOfWork> _unitOfWork;
        Mock<IMapper> _mapper;

        [TestInitialize]
        public void Initialized()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
        }
        [TestMethod]
        public void AddAppointment_ValidAppointmentDTO_ReturnTrue()
        {
            _mapper.Setup(x => x.Map<Appointment>(It.IsAny<AppointmentAddDTO>())).Returns(MockAppointments.listOfAppointment[0]);
            _unitOfWork.Setup(x => x.DentistRepository.GetAll()).Returns(MockDentists.listOfDentist);
            _unitOfWork.Setup(x => x.AppointmentRepository.Add(It.IsAny<Appointment>()));
            _unitOfWork.Setup(x => x.Save()).Returns(true);
            AppointmentBusiness business = new AppointmentBusiness(_unitOfWork.Object, _mapper.Object);
            var result = business.AddAppointment(MockAppointments.listOfAddDTOAppointment[0], "ayush");
            Assert.IsTrue(result);


        }
        [TestMethod]
        public void GetAppointmentFilter_ValidInput_ReturnListOfAppontment()
        {
            _unitOfWork.Setup(x => x.AppointmentRepository.GetAll()).Returns(MockAppointments.listOfAppointment);
            _mapper.Setup(x => x.Map<IEnumerable<AppointmentDTO>>(It.IsAny<Appointment>())).Returns(MockAppointments.listOfDTOAppointment);
            AppointmentBusiness business = new AppointmentBusiness(_unitOfWork.Object, _mapper.Object);
            var result = business.GetAppointmentFilter(null, 1, null, null, null);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DeleteAppointmentById_ValidAppointmentId_ReturnTrue()
        {
            _unitOfWork.Setup(x => x.AppointmentRepository.GetAll()).Returns(MockAppointments.listOfAppointment);
            _unitOfWork.Setup(x => x.AppointmentRepository.Delete(1));
            _unitOfWork.Setup(x=>x.Save()).Returns(true);
            AppointmentBusiness business = new AppointmentBusiness(_unitOfWork.Object, _mapper.Object);
            var result = business.DeleteAppointById(2, "ayush");
            Assert.IsTrue(result);


        }
    }
}
