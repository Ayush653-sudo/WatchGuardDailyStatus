using System.Threading.Tasks;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.Repository;
using Tooth_Booth_API.Repository.@interface;

namespace Tooth_Booth_API.UOW.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Dentist, string> DentistRepository { get; }
        IRepository<Appointment,int> AppointmentRepository { get; }
        IRepository<Clinic,int> ClinicRepository { get; }
    
        IAuthRepository AuthRepository { get; }
        bool Save();

    }
}
