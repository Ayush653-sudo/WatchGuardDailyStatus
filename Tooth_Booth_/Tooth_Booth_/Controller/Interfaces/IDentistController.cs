using Tooth_Booth_.models;

namespace Tooth_Booth_.Controller.ControllerInterfaces
{
    internal interface IDentistController
    {
        
        bool UpdateDentistAtDB(Dentist dentist);

        public Dictionary<String, String> GetDentistList(string clinicName);

        public List<Dentist> GetDentistAtClinic(string clinicUserName);

        public bool RegisterNewDentistAtClinic(User user,Dentist dentist);

        public bool DeleteDentistAtClinic(string clinicUserName, string userName);

        public Dentist GetDentist(string dentistUsername);
    }
}