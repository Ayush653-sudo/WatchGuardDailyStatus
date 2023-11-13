using Tooth_Booth_.models;

namespace Tooth_Booth_.Controller.ControllerInterfaces
{
    public interface IClinicController
    {


        bool DeleteClinic(Clinic clinic);
        List<Clinic> GeListOfAllClinic();
        Clinic GetClinicByClinicName(string userName);
        List<string> GetListOFClinicByCityName(string cityName);
        bool UpdateClinic(Clinic updatedClinic);
    }
}