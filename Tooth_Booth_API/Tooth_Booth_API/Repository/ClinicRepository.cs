using System.Collections.Generic;
using Tooth_Booth_API.Data;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.Repository
{
    public class ClinicRepository:IRepository<Clinic,int>
    {
        private readonly ApiDBContext _dbContext;

        public ClinicRepository(ApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Clinic> GetAll()
        {
            return _dbContext.Clinics;
        }

        public void Add(Clinic clinic)
        {
            _dbContext.Clinics.Add(clinic);
        }

        public void Delete(int id)
        {
           Clinic clinic = _dbContext.Clinics.Find(id);

            _dbContext.Clinics.Remove(clinic);
        }
        public void Update(Clinic clinic)
        {
            _dbContext.Clinics.Update(clinic);
        }
    }
}
