using Tooth_Booth_.models;

namespace Tooth_Booth_.Controller.Interfaces
{
    internal interface IDentistControllerForPatient
    {
        Dictionary<string, string> GetDentistList(string clinicName);

    }
}