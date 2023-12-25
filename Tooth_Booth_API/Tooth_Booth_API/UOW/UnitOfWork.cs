using Tooth_Booth_API.Models;
using Tooth_Booth_API.Repository.@interface;
using Tooth_Booth_API.Repository;
using Tooth_Booth_API.UOW.Interface;
using Microsoft.EntityFrameworkCore;
using Tooth_Booth_API.Data;
using Microsoft.AspNetCore.Identity;

namespace Tooth_Booth_API.UOW
{
    public class UnitOfWork:IUnitOfWork
    {


        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        ApiDBContext _dbContext;    
        public UnitOfWork(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApiDBContext dbContext)
        {

            _userManager = userManager;
            this.signInManager = signInManager;
            _dbContext = dbContext;
        }
        public IRepository<Dentist,string> DentistRepository => new DentistRepository(_dbContext); 
        public IRepository<Appointment,int> AppointmentRepository =>new AppointmentRepository(_dbContext);
        public IRepository<Clinic,int> ClinicRepository =>new ClinicRepository(_dbContext);
    
        public IAuthRepository AuthRepository => new AuthRepository(_userManager,signInManager);
        public bool Save()
        {
            if(_dbContext.SaveChanges()>0)
                return true;
            return false;
        }


    }
}
