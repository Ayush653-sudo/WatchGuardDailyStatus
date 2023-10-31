using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.Controller;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.models
{
     class SuperAdmin:User
    {

        public SuperAdmin() : base()
        {

        }
        public SuperAdmin(User user):base(user) 
        { }

      



    }
}
