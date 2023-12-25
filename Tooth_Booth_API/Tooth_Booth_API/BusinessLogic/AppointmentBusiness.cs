using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.UOW.Interface;
namespace Tooth_Booth_API.BusinessLogic
{
    public class AppointmentBusiness : IAppointmentBusiness
    {

        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public AppointmentBusiness(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;

        }

        public bool AddAppointment(AppointmentAddDTO appointmentInput,string userName)
        {

            var appointment = _mapper.Map<Appointment>(appointmentInput);
            appointment.AppointmentDate = DateTime.Today;
            appointment.PatientUserName = userName;
            var clinicId=  _unitOfWork.DentistRepository.GetAll().FirstOrDefault((obj) => obj.Id.Equals(appointment.DoctorId)).ClinicID;
            appointment.ClinicId = clinicId;

            _unitOfWork.AppointmentRepository.Add(appointment);
            if (_unitOfWork.Save())
            {
                return true;
            }
            return false;
        }
        public  async Task<bool> UpdateAppointment(int id, string dentistId,JsonPatchDocument<Appointment> updateAppointment)
        {

         //   IdentityUser user1 = await _userManager.GetUserAsync(ClaimsPrincipal.Current);
          
            Appointment appoint= _unitOfWork.AppointmentRepository.GetAll().FirstOrDefault((a)=>a.AppointmentId.Equals(id)&&a.DoctorId.Equals(dentistId));
            if (appoint == null)
            {
                throw new ArgumentNullException("Not able to find appointment");
            }
            updateAppointment.ApplyTo(appoint);
            _unitOfWork.AppointmentRepository.Update(appoint);
            if(_unitOfWork.Save())
            { return true; }
            return false;
        }

        public IEnumerable<AppointmentDTO> GetAppointmentFilter(DateTime? dateTime,int? appointmentId,string patientUserName,string doctorId,int? clinicId) 
        {

            IEnumerable<Appointment> appointments = _unitOfWork.AppointmentRepository.GetAll();
            var appointmentsDTO=_mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
            if (dateTime.HasValue)
            {
             appointmentsDTO=  appointmentsDTO.Where((obj)=>obj.AppointmentDate.Equals(dateTime.Value)).ToList();
            }
            if (appointmentId.HasValue)
            {
                appointmentsDTO = appointmentsDTO.Where((obj) => obj.AppointmentId.Equals(appointmentId)).ToList();
            }
            if(!string.IsNullOrEmpty(patientUserName))
            {
                appointmentsDTO = appointmentsDTO.Where((obj) => obj.PatientUserName.Equals(patientUserName)).ToList();
            }
            if (!string.IsNullOrEmpty(doctorId))
            {
                appointmentsDTO = appointmentsDTO.Where((obj) => obj.DoctorId.Equals(doctorId)).ToList();
            }
            if(clinicId.HasValue) 
            {
                appointmentsDTO = appointmentsDTO.Where((obj) => obj.ClinicId.Equals(clinicId)).ToList();  
            }

            return appointmentsDTO;
        }
       
        public  bool DeleteAppointById(int id,string userName) 
        {
         
            
            Appointment appointment = _unitOfWork.AppointmentRepository.GetAll().FirstOrDefault(obj => obj.PatientUserName.Equals(userName) &&
            obj.AppointmentId.Equals(id)&&
            obj.AppointmentDate.Equals(DateTime.Today)&&
            obj.Prescription.Length==0);
            if(appointment == null)
            {
                throw new ArgumentNullException("Not able to find Appointment");
            }
            else
            {
                _unitOfWork.AppointmentRepository.Delete(appointment.AppointmentId);
                if (_unitOfWork.Save())
                    return true;
                else
                    throw new Exception("something went wrong");

            }
            
        }


    }
}
