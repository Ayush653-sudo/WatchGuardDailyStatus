using Tooth_Booth_.models;

namespace Tooth_Booth_.Controller.ControllerInterfaces
{
    public interface IClinicControllerForSuperAdmin
    {
        bool DeleteClinic(Clinic clinic);
        List<Clinic> GeListOfAllClinic();
        Clinic GetClinicByClinicName(string userName);
        bool UpdateClinic(Clinic updatedClinic);
    }
}