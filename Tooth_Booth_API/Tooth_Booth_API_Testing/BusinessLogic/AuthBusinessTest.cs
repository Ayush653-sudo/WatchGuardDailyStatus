using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic;
using Tooth_Booth_API.DTO.Auth;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.UOW.Interface;
using Tooth_Booth_API_Testing.MockData;

namespace Tooth_Booth_API_Testing.BusinessLogic
{
    [TestClass]
    public class AuthBusinessTest
    {
        Mock<IUnitOfWork> _unitOfWork;
        Mock<IMapper> _mapper;
        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();

        }
        [TestMethod]
        public async Task AddUser_ValidIdentityInput_ReturnIndentityResultSucess()
        {
            _unitOfWork.Setup(x=>x.AuthRepository.Register(It.IsAny<IdentityUser>(),It.IsAny<string>())).ReturnsAsync(IdentityResult.Success); 
            _unitOfWork.Setup(x=>x.AuthRepository.AddToRole(It.IsAny<IdentityUser>(),It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            AuthBusiness authBusiness=new AuthBusiness(_unitOfWork.Object,_mapper.Object);
            var result = await authBusiness.AddUser(Registration.listOfIdentity[0],"ayushSingh12","Admin");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public async Task AddDentist_ValidDentistInput_ReturnSucess()
        {
            _unitOfWork.Setup(x => x.AuthRepository.Register(It.IsAny<IdentityUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            _unitOfWork.Setup(x => x.AuthRepository.AddToRole(It.IsAny<IdentityUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            _unitOfWork.Setup(x => x.ClinicRepository.GetAll()).Returns(MockClinics.listOfClinic);
            _unitOfWork.Setup(x => x.DentistRepository.Add(It.IsAny<Dentist>()));
            _unitOfWork.Setup(x => x.Save()).Returns(true);
            _mapper.Setup(x => x.Map<Dentist>(It.IsAny<DentistRegistrationDTO>())).Returns(MockDentists.listOfDentist[0]);

            AuthBusiness authBusiness = new AuthBusiness(_unitOfWork.Object, _mapper.Object);
            var result = await authBusiness.AddDentist("ayush",MockDentists.listOfDentistDTO[0]);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public async Task Login_ValidLogin_ReturnSucess()
        {
            _unitOfWork.Setup(x => x.AuthRepository.LogIn(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(SignInResult.Success);
            AuthBusiness authBusiness = new AuthBusiness(_unitOfWork.Object, _mapper.Object);
            var result = await authBusiness.LogIn(Registration.listOfUserLogin[0]);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public async Task AddClinic_ValidClinic_ReturnSuccess()
        {
            _unitOfWork.Setup(x => x.AuthRepository.Register(It.IsAny<IdentityUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            _unitOfWork.Setup(x => x.AuthRepository.AddToRole(It.IsAny<IdentityUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            _mapper.Setup(x => x.Map<Clinic>(It.IsAny<ClinicRegistrationDTO>())).Returns(MockClinics.listOfClinic[0]);
            _unitOfWork.Setup(x => x.ClinicRepository.Add(It.IsAny<Clinic>()));
            _unitOfWork.Setup(x => x.Save()).Returns(true);
            AuthBusiness authBusiness = new AuthBusiness(_unitOfWork.Object, _mapper.Object);
            var result = await authBusiness.AddClinic(MockClinics.listOfClinicRegistrationDTO[0]);
            Assert.IsTrue(result);

        }
    }
}
