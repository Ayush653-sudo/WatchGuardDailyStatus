using Tooth_Booth_.models;

namespace Tooth_Booth_.Controller.ControllerInterfaces
{
    public interface IDentistControllerForClinicAdmin
    {
        public List<Dentist> GetDentistAtClinic(string clinicUserName);

        public bool RegisterNewDentistAtClinic(User user,Dentist dentist);

        public bool DeleteDentistAtClinic(string clinicUserName, string userName);

    }
}