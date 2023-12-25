using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.UOW;
using Tooth_Booth_API.UOW.Interface;
using Tooth_Booth_API_Testing.MockData;

namespace Tooth_Booth_API_Testing.BusinessLogic
{
    [TestClass]  
    public class ClinicBusinessTest
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
        public void GetAllClinic_ValidId_ReturnListOfClinic()
        {
            _unitOfWork.Setup(x => x.ClinicRepository.GetAll()).Returns(MockClinics.listOfClinic);
            _mapper.Setup(x => x.Map<IEnumerable<ClinicDTO>>(It.IsAny<IEnumerable<Clinic>>())).Returns(MockClinics.listOfClinics);
            ClinicsBusinesscs business=new ClinicsBusinesscs(_unitOfWork.Object,_mapper.Object);
            var result = business.GetAllClinic(1, null, null, null);
            Assert.IsNotNull(result);



        }
        [TestMethod]
        public async Task DeleteClinic_ValidId_ReturnTrue()
        {
            _unitOfWork.Setup(x => x.ClinicRepository.GetAll()).Returns(MockClinics.listOfClinic);
            _unitOfWork.Setup(x => x.ClinicRepository.Delete(It.IsAny<int>()));
            _unitOfWork.Setup(x => x.Save()).Returns(true);
            _unitOfWork.Setup(x => x.AuthRepository.Find(It.IsAny<string>())).ReturnsAsync(Registration.listOfIdentity[0]);
            _unitOfWork.Setup(x => x.AuthRepository.Delete(Registration.listOfIdentity[0])).ReturnsAsync(IdentityResult.Success);
            ClinicsBusinesscs business = new ClinicsBusinesscs(_unitOfWork.Object, _mapper.Object);
            var result = await business.DeleteClinic(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }



    }
}
