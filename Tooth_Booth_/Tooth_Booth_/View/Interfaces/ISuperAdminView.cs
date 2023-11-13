using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.models;

namespace Tooth_Booth_.View.Interfaces
{
    interface ISuperAdminView
    {
        ISuperAdminController superAdminController { get; set; }
        IClinicController clinicController {  get; set; } 
        internal void StartSuperAdminView(User user);
        void ViewListOfAvailableClinic(User user);

        internal void EditClinicDashboard(User superadmin);

        void DeleteAnyClinic(User superadmin);

        void AddMoreAdmin(User superadmin);

        void LogOut(User superadmin);


    }
}
