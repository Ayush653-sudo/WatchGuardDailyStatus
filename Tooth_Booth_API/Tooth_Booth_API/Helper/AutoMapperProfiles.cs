using AutoMapper;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.DTO.Auth;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.Helper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DentistRegistrationDTO,Dentist>();
            CreateMap<ClinicRegistrationDTO, Clinic>();
            CreateMap<AppointmentAddDTO,Appointment>();
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<Clinic, ClinicDTO>();
            CreateMap<Dentist, DentistDTO>();

        }
    }
}
