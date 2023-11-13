using Tooth_Booth_.models;

namespace Tooth_Booth_.View.Interfaces
{
    public interface IAuthDashboard
    {
        Dictionary<string, string> LogInView();
        User RegistrationView();


    }
}