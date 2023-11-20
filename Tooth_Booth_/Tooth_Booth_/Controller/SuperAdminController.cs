using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.Controller.ControllerInterfaces;
using Tooth_Booth_.database;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

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
