
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.Data;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.UOW.Interface;

namespace Tooth_Booth_API.BusinessLogic
{
    public class DentistBusiness : IDentistBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DentistBusiness(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<DentistDTO> GetDentistByClinicId(int? ClinicId)
        {
           var listOfDentist=_unitOfWork.DentistRepository.GetAll();
            if (!ClinicId.HasValue)
            {
                return _mapper.Map<IEnumerable<DentistDTO>>(listOfDentist);
            }
         return _mapper.Map<IEnumerable<DentistDTO>>(listOfDentist.Where((obj)=>obj.ClinicID.Equals(ClinicId)));
            
        }
        public bool UpdateDentist(string id,JsonPatchDocument<Dentist> updateDentist)
        {

           
            
            Dentist dentist = _unitOfWork.DentistRepository.GetAll().FirstOrDefault((a) => a.Id.Equals(id));
            if (dentist == null)
            {
                return false;
            }
            updateDentist.ApplyTo(dentist);
            if (_unitOfWork.Save())
            { return true; }
            return false;
        }

        public async Task<bool> DeleteDentist(string id, string userID)
        {
           
            
            var clinicId=_unitOfWork.ClinicRepository.GetAll().FirstOrDefault((obj)=>obj.ClinicAdminId.Equals(userID)).ClinicId;
            Dentist dentist = _unitOfWork.DentistRepository.GetAll().FirstOrDefault(obj => obj.ClinicID==clinicId && obj.Id==id);
           
            if (dentist == null)
                return false;
            else
            {
                IdentityUser identityUser = await _unitOfWork.AuthRepository.Find(dentist.Id);

                var result = await _unitOfWork.AuthRepository.Delete(identityUser);
                if (result.Succeeded)

                {
               
                    _unitOfWork.DentistRepository.Delete(dentist.Id);
                   
                    if (_unitOfWork.Save())
                        return true;
                }
            }
            return false;

        }

    }
}
