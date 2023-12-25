using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.UOW.Interface;

namespace Tooth_Booth_API.BusinessLogic
{
    public class ClinicsBusinesscs:IClinicsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClinicsBusinesscs(IUnitOfWork unitOfWork,IMapper mapper)
        {

           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<ClinicDTO> GetAllClinic(int? clinicId,string clinicName,string clinicCity,bool? isVerified)
        {
            IEnumerable<Clinic> Allclinics=_unitOfWork.ClinicRepository.GetAll();
            var clinics = _mapper.Map<IEnumerable<ClinicDTO>>(Allclinics);


            if (clinicId.HasValue)
            {
                return clinics.Where((obj) => obj.ClinicId == clinicId);
            }
                   
            if(!string.IsNullOrEmpty(clinicName))
            {
              clinics=clinics.Where((obj) => obj.ClinicName == clinicName);
            }
            if (!string.IsNullOrEmpty(clinicCity))
            {
                clinics= clinics.Where((obj) => obj.ClinicCity == clinicCity);
            }
            if (isVerified.HasValue)
            {
                clinics = clinics.Where((obj) => obj.Isverified==isVerified);
            }
            return clinics;
        }
            

        


        public bool UpdateClinic(int id,JsonPatchDocument<Clinic> updateClinic)
        {



            Clinic clinic = _unitOfWork.ClinicRepository.GetAll().FirstOrDefault((a) => a.ClinicId.Equals(id));
            if (clinic == null)
            {
                return false;
            }
            updateClinic.ApplyTo(clinic);
            _unitOfWork.ClinicRepository.Update(clinic);
            if(_unitOfWork.Save())

            { return true; }
            return false;
        }
        public async Task<bool> DeleteClinic(int id)
        {
           Clinic clinic = _unitOfWork.ClinicRepository.GetAll().FirstOrDefault(obj => obj.ClinicId.Equals(id));
            if (clinic == null)
                return false;
            else
            {
                _unitOfWork.ClinicRepository.Delete(clinic.ClinicId);

                IdentityUser clinicAdmin = await _unitOfWork.AuthRepository.Find(clinic.ClinicAdminId); 
               var result=await _unitOfWork.AuthRepository.Delete(clinicAdmin);
                if (result.Succeeded)

                {
                   if( _unitOfWork.Save())
                    return true;
                }
               
            }
            return false;

        }





    }
}
