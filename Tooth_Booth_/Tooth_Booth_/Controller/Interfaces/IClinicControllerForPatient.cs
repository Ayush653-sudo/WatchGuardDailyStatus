using Tooth_Booth_.models;

namespace Tooth_Booth_.Controller.Interfaces
{
    internal interface IClinicControllerForPatient
    {     
        List<string> GetListOFClinicByCityName(string cityName);

    }
}