
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.database;
using Tooth_Booth_.models;


namespace Tooth_Booth_.Controller
{


    internal class SuperAdminController : ISuperAdminController
    {
        IDBHandler<User> userDBHandler;
        public SuperAdminController(IDBHandler<User>userDBHandler) {
        this.userDBHandler = userDBHandler;
        }
        public bool AddNewAdmin(User user)
        {
            return userDBHandler.Add(user);
        }


    }
}
