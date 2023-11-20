using Tooth_Booth_.models;

namespace Tooth_Booth_.Controller.Interfaces
{
    public interface IDentistControllerForDentist
    {
        bool DeleteDentistAtClinic(string clinicUserName, string userName);
        Dentist GetDentist(string userName);
        List<Dentist> GetDentistAtClinic(string clinicUserName);
        Dictionary<string, string> GetDentistList(string clinicName);
        bool RegisterNewDentistAtClinic(User user, Dentist dentist);
        bool UpdateDentistAtDB(Dentist dentist);
    }
}