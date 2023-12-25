
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.DTO.Auth;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.UOW.Interface;

namespace Tooth_Booth_API.BusinessLogic
{
    public class AuthBusiness:IAuthBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

      
        public AuthBusiness(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }
        public async Task<bool> AddUser(IdentityUser user,string Password, string RoleName)
        {
           
           var result=await _unitOfWork.AuthRepository.Register(user, Password); 
            
            
            if(result.Succeeded)
            {               

               
                var userManagerIdentityResutlt= await  _unitOfWork.AuthRepository.AddToRole(user,RoleName);
              
               
          
                if (!userManagerIdentityResutlt.Succeeded)
                {
                    string error = "";

                    foreach (var i in userManagerIdentityResutlt.Errors)
                    {
                        error += i.Description.ToString() + '\n';
                    }
                    throw new Exception(error);
                }
                return true;
            }
            else
            {

                string error="";
                foreach(var i in result.Errors)
                {
                    error += i.Description.ToString()+'\n';
                }
                throw new Exception(error);
            }
            
        }
        public async Task<bool>AddDentist(string clinicAdmin,DentistRegistrationDTO newDentist)
        {

            var user = new IdentityUser { UserName = newDentist.UserName, Email = newDentist.EmailAddress, PhoneNumber = newDentist.PhoneNumber };
            bool result1 = await AddUser(user, newDentist.Password, "Dentist");
            Clinic clinic=_unitOfWork.ClinicRepository.GetAll().FirstOrDefault((obj)=>obj.ClinicAdminId.Equals(clinicAdmin));

            var dentist = _mapper.Map<Dentist>(newDentist);
            dentist.Id = user.Id;
            dentist.ClinicID = clinic.ClinicId;                      
            _unitOfWork.DentistRepository.Add(dentist);
           if( _unitOfWork.Save())
            return true;
           return false;
        }
        public async Task<bool> LogIn(UserLoginDTO userLoginModel)
        {
          var result=  await _unitOfWork.AuthRepository.LogIn(userLoginModel.UserName, userLoginModel.Password);
            if(result.Succeeded)
            {
                return true;
            }

            return false;
        }
        public async Task<bool> AddClinic(ClinicRegistrationDTO clinicDTO) 
        {

            var user = new IdentityUser { UserName = clinicDTO.UserName, Email = clinicDTO.EmailAddress, PhoneNumber =clinicDTO.PhoneNumber };
            bool result1 = await AddUser(user, clinicDTO.Password, "ClinicAdmin");

            if (result1)
            {
                var newClinic = _mapper.Map<Clinic>(clinicDTO);
                newClinic.ClinicAdminId = user.Id;
                _unitOfWork.ClinicRepository.Add(newClinic);
                if (_unitOfWork.Save())
                    return true;
                else
                    throw new Exception("Not able to store info");
            }
            throw new Exception("Not able to Register User");
        }
    }
}
