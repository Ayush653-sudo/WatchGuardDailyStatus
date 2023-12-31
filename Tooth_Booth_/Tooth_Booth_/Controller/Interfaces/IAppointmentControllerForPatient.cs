﻿using Tooth_Booth_.models;

namespace Tooth_Booth_.Controller.Interfaces
{
    public interface IAppointmentControllerForPatient
    {
        bool BookNewAppointment(Appointment appointment);
        bool CancleAppointById(string userName, int id);
        List<Appointment> GetAllAppointmentByUsername(string userName);
    }
}