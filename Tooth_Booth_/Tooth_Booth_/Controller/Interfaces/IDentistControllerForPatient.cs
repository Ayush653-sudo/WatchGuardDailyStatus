using Tooth_Booth_.models;

namespace Tooth_Booth_.Controller.Interfaces
{
    public interface IDentistControllerForPatient
    {
        Dictionary<string, string> GetDentistList(string clinicName);

    }
}