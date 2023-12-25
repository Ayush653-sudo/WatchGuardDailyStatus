using System.Collections.Generic;
using Tooth_Booth_API.Data;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.Repository
{
    public class DentistRepository:IRepository<Dentist,string>
    {

        private readonly ApiDBContext _dbContext;

        public DentistRepository(ApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Dentist> GetAll()
        {
            return _dbContext.Dentists;
        }

        public void Add(Dentist dentist)
        {
            _dbContext.Dentists.Add(dentist);
        }

        public void Delete(string id)
        {
             Dentist dentist = _dbContext.Dentists.Find(id);

            _dbContext.Dentists.Remove(dentist);
        }
        public void Update(Dentist dentist)
        {
            _dbContext.Dentists.Update(dentist);
        }
    }
}
