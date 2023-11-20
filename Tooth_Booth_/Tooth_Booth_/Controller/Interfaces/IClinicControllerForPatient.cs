using Tooth_Booth_.models;

namespace Tooth_Booth_.Controller.Interfaces
{
    public interface IClinicControllerForPatient
    {     
        List<string> GetListOFClinicByCityName(string cityName);

    }
}