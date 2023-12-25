using System.Collections;
using System.Collections.Generic;
using Tooth_Booth_API.Data;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.Repository
{
    public class AppointmentRepository:IRepository<Appointment,int>
    {
        private readonly ApiDBContext _dbContext;

        public AppointmentRepository(ApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _dbContext.Appointments;
        }

        public void Add(Appointment appointment)
        {
            _dbContext.Appointments.Add(appointment);
        }

        public void Delete(int id)
        {
          Appointment appointment = _dbContext.Appointments.Find(id);
        
        _dbContext.Appointments.Remove(appointment);
        }
        public void Update(Appointment appointment)
        {
            _dbContext.Appointments.Update(appointment);
        }

    }
}
