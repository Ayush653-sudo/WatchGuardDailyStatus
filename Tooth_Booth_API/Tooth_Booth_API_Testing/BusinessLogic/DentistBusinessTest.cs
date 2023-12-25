using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.UOW.Interface;
using Tooth_Booth_API_Testing.MockData;

namespace Tooth_Booth_API_Testing.BusinessLogic
{
    [TestClass]
    public class DentistBusinessTest
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
        public void GetDentistFilter_ValidInput_ReturnListOfDentist()
        {
            _unitOfWork.Setup(x => x.DentistRepository.GetAll()).Returns(MockDentists.listOfDentist);
            _mapper.Setup(x => x.Map<IEnumerable<DentistDTO>>(It.IsAny<IEnumerable<Dentist>>())).Returns(MockDentists.listOfDentists.Where((obj)=>obj.ClinicID==1));
            DentistBusiness business = new DentistBusiness(_unitOfWork.Object, _mapper.Object);
            var result = business.GetDentistByClinicId(1);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public async Task DeleteDentist_validDentistId_ReturnSucess()
        {
            
            _unitOfWork.Setup(x => x.ClinicRepository.GetAll()).Returns(MockClinics.listOfClinic);
            _unitOfWork.Setup(x => x.DentistRepository.GetAll()).Returns(MockDentists.listOfDentist);
            _unitOfWork.Setup(x => x.AuthRepository.Find(It.IsAny<string>())).ReturnsAsync(Registration.listOfIdentity[0]);
            _unitOfWork.Setup(x => x.Save()).Returns(true);
            _unitOfWork.Setup(x => x.AuthRepository.Delete(It.IsAny<IdentityUser>())).ReturnsAsync(IdentityResult.Success);
            DentistBusiness business = new DentistBusiness(_unitOfWork.Object, _mapper.Object);
            var result = await business.DeleteDentist("ayush", "ayush");
            Assert.IsNotNull(result);
        //    Assert.IsTrue(result);

        }
        

    }
}
