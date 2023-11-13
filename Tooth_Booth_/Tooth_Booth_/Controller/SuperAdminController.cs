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


      

        public bool AddNewAdmin(User user)
        {

          

            return UserDBHandler.handler.AddEntryAtDB<User>(UserDBHandler.handler.userPath, user, UserDBHandler.handler.listOfUser);
        }


    }
}
